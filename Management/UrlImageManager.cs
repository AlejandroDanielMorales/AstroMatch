using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Management
{
    
    
        public class UrlImageManager
    {


        public List<UrlImage> imagesOfUser(int ID)
        {

            List<UrlImage> list = new List<UrlImage>();
            DataManager dataManager = new DataManager();
            try
            {

                dataManager.setQuery("Select ImagenUrl, Id, IdUsuario from IMAGENES where IdUsuario  =@ID ");
                dataManager.setParameter("@ID", ID);
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    UrlImage url = new UrlImage();
                    url.Id = (int)dataManager.Lector["Id"];
                    url.Url = (string)dataManager.Lector["ImagenUrl"];
                    url.IdUser = (int)dataManager.Lector["IdUsuario"];
                    if (url.Url == null)
                    {
                        url.Url = "https://tinyurl.com/mr2scwy8";
                    }
                    list.Add(url);

                }
                dataManager.closeConection();
                return list;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public UrlImage UserProfilePhoto(int ID)
        {
            DataManager dataManager = new DataManager();
            try
            {
                dataManager.ClearCommand();
                dataManager.setQuery("Select ImagenUrl, Id, IdUsuario from IMAGENESPerfil where IdUsuario = @ID");
                dataManager.setParameter("@ID", ID);
                dataManager.executeRead();

                UrlImage url = new UrlImage();

                if (dataManager.Lector.Read())
                {
                    url.Id = (int)dataManager.Lector["Id"];
                    url.Url = (string)dataManager.Lector["ImagenUrl"];
                    url.IdUser = (int)dataManager.Lector["IdUsuario"];
                    dataManager.closeConection();
                    return url;
                }
                else
                {
                    UrlImage url2 = new UrlImage();
                    url2.Url = "https://tinyurl.com/mr2scwy8";
                    dataManager.closeConection();
                    return url2;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddUserProfilePhoto(UrlImage url)
        {
            DataManager dataManager = new DataManager();
            try
            {
                dataManager.ClearCommand();
                dataManager.setQuery("INSERT INTO IMAGENESPerfil (ImagenUrl, IdUsuario) VALUES (@Url, @IdUsuario)");
                dataManager.setParameter("@Url", url.Url);
                dataManager.setParameter("@IdUsuario", url.IdUser);
                dataManager.executeRead(); 
                dataManager.closeConection();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteImage(int ID)
            {

                DataManager data = new DataManager();
                try
                {

                    data.setQuery("delete from IMAGENES where IdUsuario  =@ID ");
                    data.setParameter("@ID", ID);
                    data.executeRead();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    data.closeConection();
                }
            }

            public void addImage(List<UrlImage> imagesItem)
            {
                DataManager dataManager = new DataManager();
                try
                {


                    for (int i = 0; i < imagesItem.Count(); i++)
                    {

                        dataManager = new DataManager();
                        dataManager.setQuery("INSERT INTO IMAGENES (IdUsuario, ImagenUrl) values (@IDUsuario,@Url)");
                        dataManager.setParameter("@IDUsuario", imagesItem[i].IdUser);
                        dataManager.setParameter("@Url", imagesItem[i].Url);
                        dataManager.executeRead();
                        dataManager.closeConection();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dataManager.closeConection();
                }

            }


            public void updateImage(List<UrlImage> imagesItem)
            {
                DataManager dataManager = new DataManager();
                try
                {

                    for (int i = 0; i < imagesItem.Count(); i++)
                    {
                        dataManager = new DataManager();
                        dataManager.setQuery("UPDATE IMAGENES set ImagenUrl=@Url  WHERE Id = @Id");
                        dataManager.setParameter("@Url", imagesItem[i].Url);
                        dataManager.setParameter("@Id", imagesItem[i].Id);
                        dataManager.executeRead();
                        dataManager.closeConection();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dataManager.closeConection();
                }

            }

        }
    
}
