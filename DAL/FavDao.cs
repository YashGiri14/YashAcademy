using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FavDao 
    {
        public FavDTO GetFav()
        {
            using (POSTDATAEntities db = new POSTDATAEntities())
            {
                FavLogoTitle fav = db.FavLogoTitles.First();

                FavDTO dto = new FavDTO();
                dto.ID = fav.ID;
                dto.Title = fav.Title;
                dto.Logo = fav.Logo;
                dto.Fav = fav.Fav;
                return dto;
            }
        }

        public FavDTO UpdateFav(FavDTO model)
        {
            using (POSTDATAEntities db = new POSTDATAEntities())
            {
                try
                {
                    FavLogoTitle fav = db.FavLogoTitles.First();
                    FavDTO dTO = new FavDTO();
                    dTO.ID = fav.ID;
                    dTO.Fav = fav.Fav;
                    dTO.Logo = fav.Logo;
                    fav.Title = model.Title;
                    if (model.Logo != null)
                        fav.Logo = model.Logo;
                    if (model.Fav != null)
                        fav.Fav = model.Fav;
                    db.SaveChanges();
                    return dTO;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
