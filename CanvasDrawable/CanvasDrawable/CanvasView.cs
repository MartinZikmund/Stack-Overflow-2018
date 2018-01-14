using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CanvasDrawable
{
    public class CanvasView : View
    {
        Paint myPaint = new Paint();
        Color myColor = new Color();
        Path myPath = new Path(); //Bitmap bitmap; Resource res;
        private int a, b;
        Bitmap bitmap;

        public CanvasView(Context context) : base(context) //constructor
        {
            bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.green);
            //var bitmap = Bitmap.CreateBitmap(green, 100, 100, 400, 400);
            //var bm = Android.Graphics.Drawables.BitmapDrawable.CreateFromPath("E:\\[project_name]\\Resources\\drawable\\green.jpg");
            int[,] FirstPath; int arrayLength = 0;
            FirstPath = new int[,] { { 200, 350 }, { 70, 80 }, { 90, 40 }, { 10, 40 }, { 50, 80 }, { 0, 350 } };
            arrayLength = FirstPath.Length / 2;
            myPaint.SetARGB(255, 200, 255, 0);
            myPaint.SetStyle(Paint.Style.FillAndStroke);
            myPaint.StrokeWidth = 9;
            myPaint.TextSize = 40;
            myPaint.Color = Color.DarkCyan; //drawing pencil for path lines
            myColor = Color.RosyBrown; //not used for path or text, hmm
            myPath.Reset();
            myPath.MoveTo(FirstPath[0, 0], FirstPath[0, 1]);
            for (int tempint = 1; tempint < arrayLength; tempint++)
            { myPath.LineTo(FirstPath[tempint, 0], FirstPath[tempint, 1]); }

        }

        protected override void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(myColor);
            b = canvas.Height; a = canvas.Width;
            canvas.DrawText(b.ToString() + " x " + a.ToString(), 10, b - 50, myPaint);
            canvas.DrawPath(myPath, myPaint);
            //canvas.SetBitmap(Resource.Drawable.green);
            //canvas.DrawBitmap(bm, 100, 100, null);
            canvas.DrawBitmap(bitmap,100,100, null);
        }

    }
}