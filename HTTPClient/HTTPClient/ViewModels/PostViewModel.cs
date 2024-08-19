using CommunityToolkit.Mvvm.ComponentModel;
using HTTPClient.Models;
using HTTPClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HTTPClient.ViewModels
{
    public partial class PostViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Post> posts;
        PostServices postServices;
        public ICommand getPostagensCommand { get; }

        public PostViewModel()
        {
            getPostagensCommand = new Command(getPostagens);
            postServices = new PostServices();

        }

        public async void getPostagens()
        { 
            Posts = await postServices.GetPostsAsync();  
        }


    }
}
