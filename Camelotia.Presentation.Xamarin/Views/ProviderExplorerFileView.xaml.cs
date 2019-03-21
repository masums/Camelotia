﻿using Camelotia.Services.Models;
using ReactiveUI;
using ReactiveUI.XamForms;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Xamarin.Forms.Xaml;

namespace Camelotia.Presentation.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProviderExplorerFileView : ReactiveViewCell<FileModel>
    {
        public ProviderExplorerFileView()
        {
            InitializeComponent();
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Name, x => x.NameLabel.Text)
                    .DisposeWith(disposables);
                this.OneWayBind(ViewModel, x => x.Modified, x => x.ModifiedLabel.Text)
                    .DisposeWith(disposables);
                this.OneWayBind(ViewModel, x => x.Size, x => x.SizeLabel.Text)
                    .DisposeWith(disposables);

                this.WhenAnyValue(x => x.ViewModel.IsFolder)
                    .Select(folder => folder ? "fas-folder" : "fas-file")
                    .BindTo(this, x => x.IconImage.Icon)
                    .DisposeWith(disposables);
            });
        }
    }
}