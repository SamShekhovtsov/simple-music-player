﻿using System.Windows.Input;
using System.Windows.Threading;
using SimpleMusicPlayer.Base;
using SimpleMusicPlayer.Common;

namespace SimpleMusicPlayer.ViewModels
{
  public class MainWindowViewModel : ViewModelBaseNotifyPropertyChanged
  {
    private PlayControlViewModel playControlViewModel;
    private PlayInfoViewModel playInfoViewModel;
    private PlaylistsViewModel playlistsViewModel;
    private MedialibViewModel medialibViewModel;
    private ICommand showOnGitHubCmd;

    public MainWindowViewModel(Dispatcher dispatcher) {
      PlayerEngine.Instance.Configure(dispatcher);
      this.PlaylistsViewModel = new PlaylistsViewModel(dispatcher);
      this.PlayControlViewModel = new PlayControlViewModel(dispatcher, this.PlaylistsViewModel);
      this.PlayInfoViewModel = new PlayInfoViewModel(dispatcher);
      this.MedialibViewModel = new MedialibViewModel(dispatcher);
    }

    public PlayControlViewModel PlayControlViewModel {
      get { return this.playControlViewModel; }
      set {
        if (Equals(value, this.playControlViewModel)) {
          return;
        }
        this.playControlViewModel = value;
        this.OnPropertyChanged(() => this.PlayControlViewModel);
      }
    }

    public PlayInfoViewModel PlayInfoViewModel {
      get { return this.playInfoViewModel; }
      set {
        if (Equals(value, this.playInfoViewModel)) {
          return;
        }
        this.playInfoViewModel = value;
        this.OnPropertyChanged(() => this.PlayInfoViewModel);
      }
    }

    public PlaylistsViewModel PlaylistsViewModel {
      get { return this.playlistsViewModel; }
      set {
        if (Equals(value, this.playlistsViewModel)) {
          return;
        }
        this.playlistsViewModel = value;
        this.OnPropertyChanged(() => this.PlaylistsViewModel);
      }
    }

    public MedialibViewModel MedialibViewModel {
      get { return this.medialibViewModel; }
      set {
        if (Equals(value, this.medialibViewModel)) {
          return;
        }
        this.medialibViewModel = value;
        this.OnPropertyChanged(() => this.MedialibViewModel);
      }
    }

    public ICommand ShowOnGitHubCmd {
      get { return this.showOnGitHubCmd ?? (this.showOnGitHubCmd = new DelegateCommand(this.ShowOnGitHub, () => true)); }
    }

    private void ShowOnGitHub() {
      System.Diagnostics.Process.Start("https://github.com/punker76/simple-music-player");
    }
  }
}