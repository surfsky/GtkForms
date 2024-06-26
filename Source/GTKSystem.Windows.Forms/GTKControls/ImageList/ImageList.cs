﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text.RegularExpressions;

namespace System.Windows.Forms
{
    /// <summary>
    ///  The ImageList is an object that stores a collection of Images, most
    ///  commonly used by other controls, such as the ListView, TreeView, or
    ///  Toolbar. You can add either bitmaps or Icons to the ImageList, and the
    ///  other controls will be able to use the Images as they desire.
    /// </summary>

    [ToolboxItemFilter("System.Windows.Forms")]
    [DefaultProperty(nameof(Images))]
    [TypeConverter(typeof(ImageListConverter))]
    public sealed partial class ImageList : Component//, IHandle<HIMAGELIST>
    {
        private static readonly Color s_fakeTransparencyColor = Color.FromArgb(0x0d, 0x0b, 0x0c);
        private static readonly Size s_defaultImageSize = new Size(16, 16);

        private static int s_maxImageWidth;
        private static int s_maxImageHeight;
        private static bool s_isScalingInitialized;

        private NativeImageList? _nativeImageList;

        private ColorDepth _colorDepth = ColorDepth.Depth32Bit;
        private Size _imageSize = s_defaultImageSize;

        private ImageCollection? _imageCollection;

        // The usual handle virtualization problem, with a new twist: image
        // lists are lossy. At runtime, we delay handle creation as long as possible, and store
        // away the original images until handle creation (and hope no one disposes of the images!). At design time, we keep the originals around indefinitely.
        // This variable will become null when the original images are lost.
        private List<Original>? _originals = new List<Original>();
        private EventHandler? _recreateHandler;
        private EventHandler? _changeHandler;

        /// <summary>
        ///  Creates a new ImageList Control with a default image size of 16x16 pixels
        /// </summary>
        public ImageList()
        {
            if (!s_isScalingInitialized)
            {
                const int MaxDimension = 256;
                //s_maxImageWidth = ScaleHelper.ScaleToInitialSystemDpi(MaxDimension);
                //s_maxImageHeight = ScaleHelper.ScaleToInitialSystemDpi(MaxDimension);
                s_isScalingInitialized = true;
            }
        }

        /// <summary>
        ///  Creates a new ImageList Control with a default image size of 16x16
        ///  pixels and adds the ImageList to the passed in container.
        /// </summary>
        public ImageList(IContainer container) : this()
        {
            //ArgumentNullException.ThrowIfNull(container);

            container.Add(this);
        }

        public ColorDepth ColorDepth
        {
            get => _colorDepth;
            set
            {
                //SourceGenerated.EnumValidator.Validate(value);

                if (_colorDepth == value)
                {
                    return;
                }

                _colorDepth = value;
                PerformRecreateHandle(nameof(ColorDepth));
            }
        }

        private bool ShouldSerializeColorDepth() => Images.Count == 0;

        private void ResetColorDepth() => ColorDepth = ColorDepth.Depth32Bit;

        public IntPtr Handle
        {
            get
            {
                //if (_nativeImageList is null)
                //{
                //    CreateHandle();
                //}

                //return _nativeImageList.HIMAGELIST;
                return IntPtr.Zero;
            }
        }

        public bool HandleCreated => !(_nativeImageList is null);

        public ImageCollection Images => _imageCollection ??= new ImageCollection(this);

        public Size ImageSize
        {
            get => _imageSize;
            set
            {

                if (_imageSize.Width != value.Width || _imageSize.Height != value.Height)
                {
                    _imageSize = new Size(value.Width, value.Height);
                    PerformRecreateHandle(nameof(ImageSize));
                }
            }
        }

        private bool ShouldSerializeImageSize() => Images.Count == 0;

        public ImageListStreamer? ImageStream
        {
            get
            {
                if (Images.Empty)
                {
                    return null;
                }
                return new ImageListStreamer(this);
            }
            set
            {
                if (value is null)
                {
                    Images.Clear();
                    return;
                }
                if (value.ResourceInfo != null)
                {
                    //这里加载图像数据
                    string direc = System.IO.Directory.GetCurrentDirectory();
                    string path1 = $"{direc}/Resources/{value.ResourceInfo.ResourceName}";
                    string path2 = $"{direc}/Resources/{value.ResourceInfo.ResourceName.Split(".")[0]}";
                    string path3 = $"{direc}/Resources";

                    LoadOriginalImage(path1);
                    LoadOriginalImage(path2);
                    LoadOriginalImage(path3);

                    if (_originals.Count == 0)
                    {
                        MessageBox.Show("ImageList控件的图片请放到程序目录:Resources/[imagelist名]/");
                    }
                }
            }
        }
        private void LoadOriginalImage(string directory)
        {
            if (System.IO.Directory.Exists(directory))
            {
                foreach (string f in System.IO.Directory.GetFiles(directory, "*.*").Where(w => Regex.IsMatch(w, "[\\w\\W]+\\.(jpg|png|jpeg|bmp|ico)", RegexOptions.IgnoreCase)))
                {
                    Image img = Bitmap.FromFile(f);
                    Images.Add(img);
                }
            }
        }
#if DEBUG
        internal bool IsDisposed { get; private set; }
#endif

        public object? Tag { get; set; }

        public Color TransparentColor { get; set; } = Color.Transparent;

        private bool UseTransparentColor => TransparentColor.A > 0;

        public event EventHandler? RecreateHandle
        {
            add => _recreateHandler += value;
            remove => _recreateHandler -= value;
        }

        internal event EventHandler? ChangeHandle
        {
            add => _changeHandler += value;
            remove => _changeHandler -= value;
        }

        private Bitmap CreateBitmap(Original original, out bool ownsBitmap)
        {
            ownsBitmap = false;
            Bitmap bitmp = original._image as Bitmap;
            Gdk.Pixbuf pixbuf = new Gdk.Pixbuf(bitmp.PixbufData);
            int w = Math.Max(16, Math.Min(ImageSize.Width, 200));
            int h = Math.Max(16, Math.Min(ImageSize.Height, 200));
            Gdk.Pixbuf newpixbuf = pixbuf.ScaleSimple(w, h, Gdk.InterpType.Bilinear);
            ownsBitmap = true;
            return new Bitmap(w, h) { Pixbuf = newpixbuf };
        }

        private int AddIconToHandle(Original original, Icon icon)
        {
            try
            {
                //Debug.Assert(HandleCreated, "Calling AddIconToHandle when there is no handle");
                //int index = PInvoke.ImageList.ReplaceIcon(this, -1, new HandleRef<HICON>(icon, (HICON)icon.Handle));
                //if (index == -1)
                //{
                //    throw new InvalidOperationException(SR.ImageListAddFailed);
                //}

                //return index;
                return 0;
            }
            finally
            {
                if ((original._options & OriginalOptions.OwnsImage) != 0)
                {
                    // This is to handle the case were we clone the icon (see why below)
                    icon.Dispose();
                }
            }
        }

        private int AddToHandle(Bitmap bitmap)
        {
            //Debug.Assert(HandleCreated, "Calling AddToHandle when there is no handle");

            //// Calls GDI to create Bitmap.
            //HBITMAP hMask = (HBITMAP)ControlPaint.CreateHBitmapTransparencyMask(bitmap);

            //// Calls GDI+ to create Bitmap
            //HBITMAP hBitmap = (HBITMAP)ControlPaint.CreateHBitmapColorMask(bitmap, (IntPtr)hMask);

            //int index;
            //try
            //{
            //    index = PInvoke.ImageList.Add(this, hBitmap, hMask);
            //}
            //finally
            //{
            //    PInvokeCore.DeleteObject(hBitmap);
            //    PInvokeCore.DeleteObject(hMask);
            //}

            //if (index == -1)
            //{
            //    throw new InvalidOperationException(SR.ImageListAddFailed);
            //}

            //return index;
            return 0;
        }

        private void CreateHandle()
        {
            //Debug.Assert(_nativeImageList is null, "Handle already created, this may be a source of temporary GDI leaks");

            //IMAGELIST_CREATION_FLAGS flags = IMAGELIST_CREATION_FLAGS.ILC_MASK;
            //switch (_colorDepth)
            //{
            //    case ColorDepth.Depth4Bit:
            //        flags |= IMAGELIST_CREATION_FLAGS.ILC_COLOR4;
            //        break;
            //    case ColorDepth.Depth8Bit:
            //        flags |= IMAGELIST_CREATION_FLAGS.ILC_COLOR8;
            //        break;
            //    case ColorDepth.Depth16Bit:
            //        flags |= IMAGELIST_CREATION_FLAGS.ILC_COLOR16;
            //        break;
            //    case ColorDepth.Depth24Bit:
            //        flags |= IMAGELIST_CREATION_FLAGS.ILC_COLOR24;
            //        break;
            //    case ColorDepth.Depth32Bit:
            //        flags |= IMAGELIST_CREATION_FLAGS.ILC_COLOR32;
            //        break;
            //    default:
            //        Debug.Fail("Unknown color depth in ImageList");
            //        break;
            //}

            //using (ThemingScope scope = new(Application.UseVisualStyles))
            //{
            //    PInvoke.InitCommonControls();

            //    _nativeImageList?.Dispose();
            //    _nativeImageList = new NativeImageList(_imageSize, flags);
            //}

            //PInvoke.ImageList.SetBkColor(this, (COLORREF)PInvoke.CLR_NONE);

            //Debug.Assert(_originals != null, "Handle not yet created, yet original images are gone");
            for (int i = 0; i < _originals.Count; i++)
            {
                Original original = _originals[i];
                if (original._image is Icon originalIcon)
                {
                    AddIconToHandle(original, originalIcon);
                    // NOTE: if we own the icon (it's been created by us) this WILL dispose the icon to avoid a GDI leak
                    // **** original.image is NOT LONGER VALID AFTER THIS POINT ***
                }
                else
                {
                    Bitmap bitmapValue = CreateBitmap(original, out bool ownsBitmap);
                    AddToHandle(bitmapValue);
                    if (ownsBitmap)
                    {
                        bitmapValue.Dispose();
                    }
                }
            }

            _originals = null;
        }

        // Don't merge this function into Dispose() -- that base.Dispose() will damage the design time experience
        private void DestroyHandle()
        {
            if (HandleCreated)
            {
                _nativeImageList.Dispose();
                _nativeImageList = null;
                _originals = new List<Original>();
            }
        }

        /// <summary>
        ///  Releases the unmanaged resources used by the <see cref="ImageList" />
        ///  and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">
        ///  <see langword="true" /> to release both managed and unmanaged resources;
        ///  <see langword="false" /> to release only unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(_originals is null))
                {
                    // we might own some of the stuff that's not been created yet
                    foreach (Original original in _originals)
                    {
                        if ((original._options & OriginalOptions.OwnsImage) != 0)
                        {
                            ((IDisposable)original._image).Dispose();
                        }
                    }
                }

                DestroyHandle();
            }

#if DEBUG
            // At this stage we've released all resources, and the component is essentially disposed
            IsDisposed = true;
#endif

            base.Dispose(disposing);
        }

        /// <summary>
        ///  Draw the image indicated by the given index on the given Graphics
        ///  at the given location.
        /// </summary>
        public void Draw(Graphics g, Point pt, int index) => Draw(g, pt.X, pt.Y, index);

        /// <summary>
        ///  Draw the image indicated by the given index on the given Graphics
        ///  at the given location.
        /// </summary>
        public void Draw(Graphics g, int x, int y, int index) => Draw(g, x, y, _imageSize.Width, _imageSize.Height, index);

        /// <summary>
        ///  Draw the image indicated by the given index using the location, size
        ///  and raster op code specified. The image is stretched or compressed as
        ///  necessary to fit the bounds provided.
        /// </summary>
        public void Draw(Graphics g, int x, int y, int width, int height, int index)
        {
            //ArgumentOutOfRangeException.ThrowIfNegative(index);
            //ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Images.Count);

            //HDC dc = (HDC)g.GetHdc();
            //try
            //{
            //    PInvoke.ImageList.DrawEx(
            //        this,
            //        index,
            //        new HandleRef<HDC>(g, dc),
            //        x,
            //        y,
            //        width,
            //        height,
            //        (COLORREF)PInvoke.CLR_NONE,
            //        (COLORREF)PInvoke.CLR_NONE,
            //        IMAGE_LIST_DRAW_STYLE.ILD_TRANSPARENT);
            //}
            //finally
            //{
            //    g.ReleaseHdcInternal(dc);
            //}
        }

        private static unsafe void CopyBitmapData(BitmapData sourceData, BitmapData targetData)
        {
            Debug.Assert(Image.GetPixelFormatSize(sourceData.PixelFormat) == 32);
            Debug.Assert(Image.GetPixelFormatSize(sourceData.PixelFormat) == Image.GetPixelFormatSize(targetData.PixelFormat));
            Debug.Assert(targetData.Width == sourceData.Width);
            Debug.Assert(targetData.Height == sourceData.Height);
            Debug.Assert(targetData.Stride == targetData.Width * 4);

            // do the actual copy
            int offsetSrc = 0;
            int offsetDest = 0;
            for (int i = 0; i < targetData.Height; i++)
            {
                IntPtr srcPtr = sourceData.Scan0 + offsetSrc;
                IntPtr destPtr = targetData.Scan0 + offsetDest;
                int length = Math.Abs(targetData.Stride);
                Buffer.MemoryCopy(srcPtr.ToPointer(), destPtr.ToPointer(), length, length);
                offsetSrc += sourceData.Stride;
                offsetDest += targetData.Stride;
            }
        }

        private static unsafe bool BitmapHasAlpha(BitmapData bmpData)
        {
            if (bmpData.PixelFormat != PixelFormat.Format32bppArgb && bmpData.PixelFormat != PixelFormat.Format32bppRgb)
            {
                return false;
            }

            for (int i = 0; i < bmpData.Height; i++)
            {
                int offsetRow = i * bmpData.Stride;
                for (int j = 3; j < bmpData.Width * 4; j += 4) // *4 is safe since we know PixelFormat is ARGB
                {
                    byte* candidate = ((byte*)bmpData.Scan0.ToPointer()) + offsetRow + j;
                    if (*candidate != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///  Returns the image specified by the given index. The bitmap returned is a
        ///  copy of the original image.
        /// </summary>
        // NOTE: forces handle creation, so doesn't return things from the original list

        private Bitmap GetBitmap(int index)
        {
            Bitmap bitmp = _originals[index]._image as Bitmap;
            Gdk.Pixbuf pixbuf = new Gdk.Pixbuf(bitmp.PixbufData);
            int w = Math.Max(16, Math.Min(ImageSize.Width, 200));
            int h = Math.Max(16, Math.Min(ImageSize.Height, 200));
            Gdk.Pixbuf newpixbuf = pixbuf.ScaleSimple(w, h, Gdk.InterpType.Bilinear);
            return new Bitmap(w, h) { Pixbuf = newpixbuf };
        }

        /// <summary>
        ///  Called when the Handle property changes.
        /// </summary>
        private void OnRecreateHandle(EventArgs eventargs) => _recreateHandler?.Invoke(this, eventargs);

        private void OnChangeHandle(EventArgs eventargs) => _changeHandler?.Invoke(this, eventargs);

        // PerformRecreateHandle doesn't quite do what you would suspect.
        // Any existing images in the imagelist will NOT be copied to the
        // new image list -- they really should.

        // The net effect is that if you add images to an imagelist, and
        // then e.g. change the ImageSize any existing images will be lost
        // and you will have to add them back. This is probably a corner case
        // but it should be mentioned.
        //
        // The fix isn't as straightforward as you might think, i.e. we
        // cannot just blindly store off the images and copy them into
        // the newly created imagelist. E.g. say you change the ColorDepth
        // from 8-bit to 32-bit. Just copying the 8-bit images would be wrong.
        // Therefore we are going to leave this as is. Users should make sure
        // to set these properties before actually adding the images.

        // The Designer works around this by shadowing any Property that ends
        // up calling PerformRecreateHandle (ImageSize, ColorDepth, ImageStream).

        // Thus, if you add a new Property to ImageList which ends up calling
        // PerformRecreateHandle, you must shadow the property in ImageListDesigner.
        private void PerformRecreateHandle(string reason)
        {
            if (!HandleCreated)
            {
                return;
            }

            if (_originals is null || Images.Empty)
            {
                // spoof it into thinking this is the first CreateHandle
                _originals = new List<Original>();
            }

            DestroyHandle();
            CreateHandle();
            OnRecreateHandle(EventArgs.Empty);
        }

        private void ResetImageSize() => ImageSize = s_defaultImageSize;

        private void ResetTransparentColor() => TransparentColor = Color.LightGray;

        private bool ShouldSerializeTransparentColor() => !TransparentColor.Equals(Color.LightGray);

        /// <summary>
        ///  Returns a string representation for this control.
        /// </summary>
        public override string ToString()
            => Images is null
               ? base.ToString()
               : $"{base.ToString()} Images.Count: {Images.Count}, ImageSize: {ImageSize}";

        //HIMAGELIST IHandle<HIMAGELIST>.Handle => HIMAGELIST;

        //internal HIMAGELIST HIMAGELIST => (HIMAGELIST)Handle;
    }
}