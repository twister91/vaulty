﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using K4os.Compression.LZ4.Streams;

namespace Vaulty.Database.Models
{
    internal class User : Model
    {
        private static string Table = "users";
        private static Dictionary<string , Object> Fields = new Dictionary<string , Object>();

        string Name;
        string Username;
        string Password;
        string Img;
        string Lang;
        List<Identity> identities;
        
        User(
            string name = null,
            string username = null,
            string password = null,
            string img = null,
            string lang = null,
            bool save = true
            )
        {
            if (
                name != null &&
                username != null &&
                password != null &&
                img != null &&
                lang != null &&
                save
                )
            {
                Fields["name"] = name;
                Fields["username"] = username;
                Fields["password"] = password;
                Fields["img"] = img;
                Fields["lang"] = lang;
                InitModel(Table , Fields);
                Insert();
            }
            else
            {
                Name = name;
                Username = username;
                Password = password;
                Img = img;
                Lang = lang;
            }
        }

        void Save()
        {
            Fields["name"] = Name;
            Fields["username"] = Username;
            Fields["password"] = Password;
            Fields["img"] = Img;
            Fields["lang"] = Lang;
            InitModel(Table, Fields);
            Insert();
        }


        internal List<User> Get()
        {
            this.GetRecords();
        }
    }
}
