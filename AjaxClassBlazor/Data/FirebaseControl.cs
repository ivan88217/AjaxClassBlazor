using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace AjaxClassBlazor.Data
{
    public class FirebaseControl
    {
        string projectId;
        FirestoreDb fireStoreDb;
        public FirebaseControl()
        {
            projectId = "formal-wonder-238506";
            fireStoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<List<Users>> getUser()
        {
            try
            {
                var usersCollection = fireStoreDb.Collection("users");
                var results = await usersCollection.GetSnapshotAsync().ConfigureAwait(false);
                var users = new List<Users>();
                foreach(var result in results.Documents)
                {
                    if (!result.Exists) break;
                    var userDiction = result.ToDictionary(); 
                    var json = JsonConvert.SerializeObject(userDiction);
                    var user = JsonConvert.DeserializeObject<Users>(json);
                    user.name = result.Id;
                    users.Add(user);
                }
                return users;
            } 
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }


        public async void AddUser(Users user)
        {
            try
            {
                CollectionReference colRef = fireStoreDb.Collection("users");
                await colRef.AddAsync(user).ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
        }
    }
}
