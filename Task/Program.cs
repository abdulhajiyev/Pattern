using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dialog dialog = new WindowsDialog();
            IButton btn = dialog.CreateButton();
            btn.Render();
            btn.OnClick();
        }
    }

    public abstract class Dialog
    {
        public void Render()
        {
        }

        public abstract IButton CreateButton();
    }

    public interface IButton
    {
        public void Render();

        public void OnClick();
    }

    class WindowsButton : IButton
    {
        public void OnClick()
        {
            Console.WriteLine("WindowsButtonOnClick");
        }

        public void Render()
        {
            Console.WriteLine("WindowsButtonRender");
        }
    }
    class HTMLButton : IButton
    {
        public void OnClick()
        {
            Console.WriteLine("HTMLOnClick");
        }

        public void Render()
        {
            Console.WriteLine("HTMLRender");
        }
    }

    class WindowsDialog : Dialog
    {
        public override IButton CreateButton() => new WindowsButton();
    }

    class WebDialog : Dialog
    {
        public override IButton CreateButton() => new HTMLButton();
    }
}
