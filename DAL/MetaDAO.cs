using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MetaDAO : PostContext
    {
        public int AddMeta(Meta meta)
        {
            try
            {
                db.Metas.Add(meta);
                db.SaveChanges();
                return meta.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
                
          
        }


        public List<MetaDTO> GetMetaData()
        {
           List<MetaDTO> metalist = new List<MetaDTO>();
            List<Meta> list = db.Metas.Where(x=>x.isDeleted==false).OrderBy(x=>x.AddDate).ToList();
            foreach (var item in list) 
            {
                MetaDTO dTO = new MetaDTO();
                dTO.MetaID = item.ID;
                dTO.Name = item.Name;
                dTO.MetaContent = item.MetaContent;
                metalist.Add(dTO);
            }

            return metalist;

        }

        public MetaDTO GetMetaWithID(int ID)
        {
            Meta meta = db.Metas.First(x=>x.ID==ID);
            MetaDTO dTO = new MetaDTO();
            dTO.MetaID = meta.ID;
            dTO.Name = meta.Name;
            dTO.MetaContent= meta.MetaContent;
            return dTO;
        }

        public void UpdateMeta(MetaDTO model)
        {
            try
            {
                Meta meta = db.Metas.First(x => x.ID == model.MetaID);  
                meta.Name = model.Name;
                meta.MetaContent = model.MetaContent;
                meta.LastUpdateDate = DateTime.Now;
                meta.LastUpdateUserID = UserStatic.UserID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteMeta(int ID)
        {
            try
            {
                Meta meta = db.Metas.First(x => x.ID == ID);
                meta.isDeleted = true;  
                meta.DeletedDate = DateTime.Now;
                meta.LastUpdateDate= DateTime.Now;
                meta.LastUpdateUserID= UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }   
        }
    }
}
