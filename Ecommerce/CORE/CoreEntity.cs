using System;
using System.Security.Principal;
using COMMON;
using CORE.Enum;
namespace CORE
{
    public class CoreEntity : IEntity<Guid>
    {
        public CoreEntity()
        {
            //CreatedDate = DateTime.Now;
            //CreatedComputerName = Environment.MachineName;
            //CreatedAdUsername = WindowsIdentity.GetCurrent().Name;
            //CreatedBy = "admin";
            
            //CreatedIP = IPAddresses.GetHostName();
        }
        public Guid ID { get ; set  ; }

        public int MasterId { get; set; }

        public Status Status { get; set; }


        //Verileri Oluşturma
        public DateTime CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }//FATIH
        public string CreatedAdUsername { get; set; }//FatihGunalp
        public string CreatedIP { get; set; }//192.168.1.1
        public string CreatedBy { get; set; }//admin


        //Verileri Güncelleme

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedAdUsername { get; set; }
        public string ModifiedIP { get; set; }
        public string ModifiedBy { get; set; }
        

    }
}

