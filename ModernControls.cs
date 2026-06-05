using System.Drawing.Drawing2D;

namespace hel_py;

public sealed class CirclePictureBox : PictureBox
{
    public Color BorderColor { get; set; } = Color.FromArgb(255, 140, 0);
    public int BorderThickness { get; set; } = 3;

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.Clear(Parent?.BackColor ?? BackColor);

        Rectangle imageBounds = new(BorderThickness, BorderThickness, Width - BorderThickness * 2, Height - BorderThickness * 2);
        using GraphicsPath imagePath = new();
        imagePath.AddEllipse(imageBounds);

        if (Image is not null)
        {
            Region previousClip = e.Graphics.Clip;
            e.Graphics.SetClip(imagePath);
            e.Graphics.DrawImage(Image, imageBounds);
            e.Graphics.Clip = previousClip;
        }

        using Pen borderPen = new(BorderColor, BorderThickness);
        e.Graphics.DrawEllipse(borderPen, imageBounds);
    }
}

public class RoundedPanel : Panel
{
    public int BorderRadius { get; set; } = 18;
    public Color BorderColor { get; set; } = Color.FromArgb(71, 78, 80);
    public int BorderThickness { get; set; } = 1;

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        Rectangle bounds = new(0, 0, Width - 1, Height - 1);

        using GraphicsPath path = CreateRoundPath(bounds, BorderRadius);
        using SolidBrush backgroundBrush = new(BackColor);
        e.Graphics.FillPath(backgroundBrush, path);

        if (BorderThickness > 0)
        {
            using Pen borderPen = new(BorderColor, BorderThickness);
            e.Graphics.DrawPath(borderPen, path);
        }
    }

    protected override void OnResize(EventArgs eventargs)
    {
        base.OnResize(eventargs);
        using GraphicsPath path = CreateRoundPath(new Rectangle(0, 0, Width, Height), BorderRadius);
        Region = new Region(path);
    }

    internal static GraphicsPath CreateRoundPath(Rectangle bounds, int radius)
    {
        int diameter = Math.Max(1, radius * 2);
        GraphicsPath path = new();

        path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
        path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        return path;
    }
}

public sealed class ModernButton : Button
{
    private bool isHovered;
    private bool isPressed;

    public int BorderRadius { get; set; } = 14;
    public Color NormalBackColor { get; set; } = Color.FromArgb(43, 49, 52);
    public Color HoverBackColor { get; set; } = Color.FromArgb(61, 68, 71);
    public Color PressedBackColor { get; set; } = Color.FromArgb(35, 40, 42);
    public Color BorderColor { get; set; } = Color.FromArgb(84, 90, 92);
    public int BorderThickness { get; set; } = 1;

    public ModernButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        UseVisualStyleBackColor = false;
        Cursor = Cursors.Hand;
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        isHovered = true;
        Invalidate();
        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        isHovered = false;
        isPressed = false;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        isPressed = true;
        Invalidate();
        base.OnMouseDown(mevent);
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        isPressed = false;
        Invalidate();
        base.OnMouseUp(mevent);
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle bounds = new(0, 0, Width - 1, Height - 1);
        Color fill = isPressed ? PressedBackColor : isHovered ? HoverBackColor : NormalBackColor;

        using GraphicsPath path = RoundedPanel.CreateRoundPath(bounds, BorderRadius);
        using SolidBrush backgroundBrush = new(fill);
        pevent.Graphics.FillPath(backgroundBrush, path);

        if (BorderThickness > 0)
        {
            using Pen borderPen = new(BorderColor, BorderThickness);
            pevent.Graphics.DrawPath(borderPen, path);
        }

        Rectangle textBounds = new(Padding.Left, 0, Width - Padding.Left - Padding.Right, Height);
        TextRenderer.DrawText(
            pevent.Graphics,
            Text,
            Font,
            textBounds,
            ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
    }
}
