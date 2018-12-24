using System;
using MLToolkit.Forms.SwipeCardView.Core;
using MvvmCross.Forms.Views;
using SwipeCardViewExample.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwipeCardViewExample.Forms.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TinderView : MvxContentPage<TinderViewModel>
    {
        public TinderView()
        {
            InitializeComponent();
            this.SwipeCardView.Dragging += this.OnDragging;
            this.SwipeCardView.Threshold = (uint)(FormsApp.ScreenWidth / 3);
        }

        private void OnDragging(object sender, DraggingCardEventArgs e)
        {
            var view = (View)sender;
            var nopeFrame = view.FindByName<Frame>("NopeFrame");
            var likeFrame = view.FindByName<Frame>("LikeFrame");
            var superLikeFrame = view.FindByName<Frame>("SuperLikeFrame");
            var threshold = (uint)(FormsApp.ScreenWidth / 3);

            var draggedXPercent = e.DistanceDraggedX / threshold;

            var draggedYPercent = e.DistanceDraggedY / threshold;

            switch (e.Position)
            {
                case DraggingCardPosition.Start:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    superLikeFrame.Opacity = 0;
                    //nopeButton.Scale = 1;
                    //likeButton.Scale = 1;
                    //superLikeButton.Scale = 1;
                    break;
                case DraggingCardPosition.UnderThreshold:
                    if (e.Direction == SwipeCardDirection.Left)
                    {
                        nopeFrame.Opacity = (-1) * draggedXPercent;
                        //nopeButton.Scale = 1 + draggedXPercent / 2;
                        superLikeFrame.Opacity = 0;
                        //superLikeButton.Scale = 1;

                    }
                    else if (e.Direction == SwipeCardDirection.Right)
                    {
                        likeFrame.Opacity = draggedXPercent;
                        //likeButton.Scale = 1 - draggedXPercent / 2;
                        superLikeFrame.Opacity = 0;
                        //superLikeButton.Scale = 1;

                    }
                    else if (e.Direction == SwipeCardDirection.Up)
                    {
                        nopeFrame.Opacity = 0;
                        likeFrame.Opacity = 0;
                        //nopeButton.Scale = 1;
                        //likeButton.Scale = 1;
                        superLikeFrame.Opacity = (-1) * draggedYPercent;
                        //superLikeButton.Scale = 1 + draggedYPercent / 2;
                    }
                    break;
                case DraggingCardPosition.OverThreshold:
                    if (e.Direction == SwipeCardDirection.Left)
                    {
                        nopeFrame.Opacity = 1;
                        superLikeFrame.Opacity = 0;
                    }
                    else if (e.Direction == SwipeCardDirection.Right)
                    {
                        likeFrame.Opacity = 1;
                        superLikeFrame.Opacity = 0;
                    }
                    else if (e.Direction == SwipeCardDirection.Up)
                    {
                        nopeFrame.Opacity = 0;
                        likeFrame.Opacity = 0;
                        superLikeFrame.Opacity = 1;
                    }
                    break;
                case DraggingCardPosition.FinishedUnderThreshold:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    superLikeFrame.Opacity = 0;
                    //nopeButton.Scale = 1;
                    //likeButton.Scale = 1;
                    //superLikeButton.Scale = 1;
                    break;
                case DraggingCardPosition.FinishedOverThreshold:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    superLikeFrame.Opacity = 0;
                    //nopeButton.Scale = 1;
                    //likeButton.Scale = 1;
                    //superLikeButton.Scale = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
