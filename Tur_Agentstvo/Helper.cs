using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Tur_Agentstvo
{
    public class Helper
    {
        public static Models.AgentstvoEntities a_agentstvo;

        public static Models.AgentstvoEntities getContext()
        {
            if(a_agentstvo == null)
            {
                a_agentstvo = new Models.AgentstvoEntities();
            }
            return a_agentstvo;
        }
        public void CreateUsers(Models.Avtorizacia avtorizacia)
        {

            a_agentstvo.Avtorizacia.Add(avtorizacia);
            a_agentstvo.SaveChanges();
        }
    }
}
