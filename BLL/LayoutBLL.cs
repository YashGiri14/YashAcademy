﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LayoutBLL
    {
        CategoryDAO categorydao = new CategoryDAO();
        SocialMediaDAO socialdao = new SocialMediaDAO();
        FavDao FavDao = new FavDao();
        MetaDAO metadao = new MetaDAO();
        AddressDAO addressdao = new AddressDAO();
        PostDAO postdao = new PostDAO();
        public HomeLayoutDTO GetlayoutData()
        {
           HomeLayoutDTO dto = new HomeLayoutDTO();
            dto.Categories = categorydao.GetCategories();
            List<SocialMediaDTO> socialmedialist = new List<SocialMediaDTO>();
            socialmedialist = socialdao.GetSocialMedias();
            dto.Facebook = socialmedialist.First(x => x.Link.Contains("facebook"));
            dto.Twitter = socialmedialist.First(x => x.Link.Contains("twitter"));
            dto.SnapChat = socialmedialist.First(x => x.Link.Contains("snapchat"));
            dto.Instagram = socialmedialist.First(x => x.Link.Contains("instagram"));
            dto.Youtube = socialmedialist.First(x => x.Link.Contains("youtube"));
        //    dto.Linkedin = socialmedialist.First(x => x.Link.Contains("linkdin"));
           dto.FavDTO = FavDao.GetFav();
            dto.Metalist = metadao.GetMetaData();
            List<AddressDTO> addresslist = addressdao.GetAddresses();
            dto.Address = addresslist.First();
            dto.HotNews = postdao.GetHotNews();
            return dto;
        }
    }
}
