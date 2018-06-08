using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductReview: AbstractBusinessObject
        {
                public BOProductReview() : base()
                {
                }

                public void SetProperties(int productReviewID,
                                          string comments,
                                          string emailAddress,
                                          DateTime modifiedDate,
                                          int productID,
                                          int rating,
                                          DateTime reviewDate,
                                          string reviewerName)
                {
                        this.Comments = comments;
                        this.EmailAddress = emailAddress;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.ProductReviewID = productReviewID;
                        this.Rating = rating;
                        this.ReviewDate = reviewDate;
                        this.ReviewerName = reviewerName;
                }

                public string Comments { get; private set; }

                public string EmailAddress { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public int ProductReviewID { get; private set; }

                public int Rating { get; private set; }

                public DateTime ReviewDate { get; private set; }

                public string ReviewerName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>19dc120dfdfe58f0f184cfc197599ad5</Hash>
</Codenesium>*/