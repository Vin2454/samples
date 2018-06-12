using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractWorkerMapper
        {
                public virtual BOWorker MapModelToBO(
                        string id,
                        ApiWorkerRequestModel model
                        )
                {
                        BOWorker boWorker = new BOWorker();

                        boWorker.SetProperties(
                                id,
                                model.CommunicationStyle,
                                model.Fingerprint,
                                model.IsDisabled,
                                model.JSON,
                                model.MachinePolicyId,
                                model.Name,
                                model.RelatedDocumentIds,
                                model.Thumbprint,
                                model.WorkerPoolIds);
                        return boWorker;
                }

                public virtual ApiWorkerResponseModel MapBOToModel(
                        BOWorker boWorker)
                {
                        var model = new ApiWorkerResponseModel();

                        model.SetProperties(boWorker.CommunicationStyle, boWorker.Fingerprint, boWorker.Id, boWorker.IsDisabled, boWorker.JSON, boWorker.MachinePolicyId, boWorker.Name, boWorker.RelatedDocumentIds, boWorker.Thumbprint, boWorker.WorkerPoolIds);

                        return model;
                }

                public virtual List<ApiWorkerResponseModel> MapBOToModel(
                        List<BOWorker> items)
                {
                        List<ApiWorkerResponseModel> response = new List<ApiWorkerResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>3dca924228c3275a52541ce78c745ea4</Hash>
</Codenesium>*/