using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductPhoto: AbstractBusinessObject
        {
                public BOProductPhoto() : base()
                {
                }

                public void SetProperties(int productPhotoID,
                                          byte[] largePhoto,
                                          string largePhotoFileName,
                                          DateTime modifiedDate,
                                          byte[] thumbNailPhoto,
                                          string thumbnailPhotoFileName)
                {
                        this.LargePhoto = largePhoto;
                        this.LargePhotoFileName = largePhotoFileName;
                        this.ModifiedDate = modifiedDate;
                        this.ProductPhotoID = productPhotoID;
                        this.ThumbNailPhoto = thumbNailPhoto;
                        this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
                }

                public byte[] LargePhoto { get; private set; }

                public string LargePhotoFileName { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductPhotoID { get; private set; }

                public byte[] ThumbNailPhoto { get; private set; }

                public string ThumbnailPhotoFileName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>91e07f8fa04525820bd47497c0b4dec5</Hash>
</Codenesium>*/