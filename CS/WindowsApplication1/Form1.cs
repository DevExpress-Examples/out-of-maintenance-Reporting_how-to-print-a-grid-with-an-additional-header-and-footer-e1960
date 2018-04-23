using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraPrinting;

namespace WindowsApplication1 {
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender,EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.nwindDataSet.Categories);

        }

        private void button1_Click(object sender,EventArgs e) {
            CompositeLink compLink = new CompositeLink(new PrintingSystem());
            PrintableComponentLink gridLink= new PrintableComponentLink();
            gridLink.Component = gridControl1;
            Link headerLink = new Link();
            headerLink.CreateDetailArea += new CreateAreaEventHandler(headerLink_CreateDetailArea);
            Link footerLink = new Link();
            footerLink.CreateDetailArea += new CreateAreaEventHandler(footerLink_CreateDetailArea);
            compLink.Links.Add(headerLink);
            compLink.Links.Add(gridLink);
            compLink.Links.Add(footerLink);

            compLink.ShowPreviewDialog();
        }

        void footerLink_CreateDetailArea(object sender,CreateAreaEventArgs e) {
            TextBrick brick = new TextBrick(BorderSide.None,0,Color.White,Color.Gray,Color.Blue);
            brick.Text = "some footer text";
            brick.Rect = new RectangleF(0,0,400,20);
            e.Graph.DrawBrick(brick);
        }

        void headerLink_CreateDetailArea(object sender,CreateAreaEventArgs e) {
            e.Graph.DrawString("Some header text",new RectangleF(0,0,400,20));
        }
    }
}