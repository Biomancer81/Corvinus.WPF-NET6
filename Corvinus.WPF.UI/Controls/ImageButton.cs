using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Corvinus.WPF.UI.Controls
{
    /// <summary>
    /// A Button that allows an image or geometry to be used in addition to the text.
    /// </summary>
    public class ImageButton : Button
    {
        /// <summary>
        /// DependencyProperty used to store raster image data.
        /// </summary>
        public static readonly DependencyProperty ImageContentProperty = DependencyProperty.Register("ImageContent", typeof(object), typeof(ImageButton), new UIPropertyMetadata(null));

        /// <summary>
        /// DependencyProperty used to store the SolidColorBrush for the background onMouseOver.
        /// </summary>
        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register("MouseOverForeground", typeof(SolidColorBrush), typeof(ImageButton), new UIPropertyMetadata(null));

        /// <summary>
        /// DependencyProperty used to store the SolidColorBrush for the background onMouseOver.
        /// </summary>
        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register("MouseOverBackground", typeof(SolidColorBrush), typeof(ImageButton), new UIPropertyMetadata(null));

        /// <summary>
        /// DependencyProperty used to store the SolidColorBrush for the background onMouseDown.
        /// </summary>
        public static readonly DependencyProperty MouseDownForegroundProperty = DependencyProperty.Register("MouseDownForeground", typeof(SolidColorBrush), typeof(ImageButton), new UIPropertyMetadata(null));

        /// <summary>
        /// DependencyProperty used to store the SolidColorBrush for the background onMouseDown.
        /// </summary>
        public static readonly DependencyProperty MouseDownBackgroundProperty = DependencyProperty.Register("MouseDownBackground", typeof(SolidColorBrush), typeof(ImageButton), new UIPropertyMetadata(null));

        /// <summary>
        /// DependencyProperty used to store the integer for the FontSize.
        /// </summary>
        public static readonly DependencyProperty FontSizePropertyProperty = DependencyProperty.Register("FontSize", typeof(int), typeof(ImageButton), new UIPropertyMetadata(null));

        /// <summary>
        /// DependencyProperty used to store the Geometry for a Vector.
        /// </summary>
        public static readonly DependencyProperty ImageGeometryProperty = DependencyProperty.Register("ImageGeometry", typeof(Geometry), typeof(ImageButton), new UIPropertyMetadata(null));

        /// <summary>
        /// Initializes static members of the <see cref="ImageButton"/> class.
        /// </summary>
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        /// <summary>
        /// Gets or sets image file. Can be used in place of Geometry.
        /// </summary>
        public object ImageContent
        {
            get { return (object)this.GetValue(ImageContentProperty); }
            set { this.SetValue(ImageContentProperty, value); }
        }

        /// <summary>
        /// Gets or sets Background Color on MouseOverEvent.
        /// </summary>
        public SolidColorBrush MouseOverForeground
        {
            get { return (SolidColorBrush)this.GetValue(MouseOverForegroundProperty); }
            set { this.SetValue(MouseOverForegroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets Background Color on MouseOverEvent.
        /// </summary>
        public SolidColorBrush MouseOverBackground
        {
            get { return (SolidColorBrush)this.GetValue(MouseOverBackgroundProperty); }
            set { this.SetValue(MouseOverBackgroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets Background Color on MouseDownEvent.
        /// </summary>
        public SolidColorBrush MouseDownForeground
        {
            get { return (SolidColorBrush)this.GetValue(MouseDownForegroundProperty); }
            set { this.SetValue(MouseDownForegroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets Background Color on MouseDownEvent.
        /// </summary>
        public SolidColorBrush MouseDownBackground
        {
            get { return (SolidColorBrush)this.GetValue(MouseDownForegroundProperty); }
            set { this.SetValue(MouseDownForegroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets Font Size for Text.
        /// </summary>
        public new int FontSizeProperty
        {
            get { return (int)this.GetValue(FontSizePropertyProperty); }
            set { this.SetValue(FontSizePropertyProperty, value); }
        }

        /// <summary>
        /// Gets or sets Geometry Resource.
        /// </summary>
        public Geometry ImageGeometry
        {
            get { return (Geometry)this.GetValue(ImageGeometryProperty); }
            set { this.SetValue(ImageGeometryProperty, value); }
        }
    }
}
