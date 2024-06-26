using DATALAYERdb;
using MODELSdb;
using System.Xml.Linq;

namespace BUSINESSLOGICdb
{
    public class VerifyingUser
    {

        OwnerData data;

        public VerifyingUser()
        {
            data = new OwnerData();
        }

        public List<OwnerContent> GetAllUsers()
        {
            return data.GetUsers();
        }

        public bool VerifysUser(string username, string password)
        {
            OwnerData ownerData = new OwnerData();
            var user = ownerData.GetUsers();
            return user != null;
        }

    }
}
