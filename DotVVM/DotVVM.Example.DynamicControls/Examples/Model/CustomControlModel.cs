using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Example.DynamicControls.Examples.Data;

namespace DotVVM.Example.DynamicControls.Examples.Model
{
    public class CustomControlModel
    {
        private readonly static Dictionary<int, UserInfoData> _fakeBD = new Dictionary<int, UserInfoData>()
        {
            { 1, new UserInfoData(){ ID = 1, Name = "User1", Email ="User1@test"} },
            { 2, new UserInfoData(){ ID = 2, Name = "User2", Email ="User2@test"} },
            { 3, new UserInfoData(){ ID = 3, Name = "User3", Email ="User3@test"} }
        };

        public UserInfoData[] Users => _fakeBD.Values.ToArray();

        public UserInfoData GetUserData(int id)
        {
            _fakeBD.TryGetValue(id, out UserInfoData value);
            return value;
        }

        public void Save(UserInfoData value)
        {
            _fakeBD[value.ID] = value;
        }
    }

}
