using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
namespace Linkdout.Moodels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string UNHASHEDpassword { get; set; }

    }

}