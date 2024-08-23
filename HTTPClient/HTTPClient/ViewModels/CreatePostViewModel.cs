using CommunityToolkit.Mvvm.ComponentModel;
using HTTPClient.Models;
using HTTPClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HTTPClient.ViewModels
{
    public partial class CreatePostViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;
        [ObservableProperty]
        string body;
        [ObservableProperty]
        int id;
        [ObservableProperty]
        int userId = 2;

        public ICommand SavePostCommand { get; }

        CreatePostViewModel()
        {
            SavePostCommand = new Command(SavePost);
        }

        public async void SavePost()
        {
            //TO DO
            Post post = new Post();
            Post newPost = new Post();
            post.Title = Title;
            post.Body = Body;
            post.UserId = userId;

            PostServices postService = new PostServices();
            newPost = await postService.SavePostAsync(post);
            
        }
    }
}
