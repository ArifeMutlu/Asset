
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebExperience.Test.Models;
using WebExperience.Test.Models.dtos;

namespace WebExperience.Test.Controllers
{
    public class AssetController : ApiController
    {
        // TODO
        // Create an API controller via REST to perform all CRUD operations on the asset objects created as part of the CSV processing test
        // Visualize the assets in a paged overview showing the title and created on field
        // Clicking an asset should navigate the user to a detail page showing all properties
        // Any data repository is permitted  
        // Use a client MVVM framework

        ApplicationDbContext _db;
        public AssetController()
        {
            _db = new ApplicationDbContext();
        }

        [System.Web.Http.Route("api/Get")]
        public IEnumerable<Asset> Get()
        {
            var query = _db.assets.ToList();
            return query;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Get/{id}")]
        public Assetdto Get(Guid id)
        {
            var query = _db.assets.FirstOrDefault(x => x.asset_id == id);
            var asset=new Assetdto();
            MapperDto(query,asset);
            return asset;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Create")]

        public Asset Create(Assetdto data)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            var asset=new Asset();
            if (data.isNew)
            {
                Mapper(data, asset);
                _db.assets.Add(asset);
            }
            else
            {
                asset = _db.assets.FirstOrDefault(x => x.asset_id == data.asset_id);
                if (asset != null)
                {
                    asset.mime_type = data.mime_type;
                    asset.country = data.country;
                    asset.created_by = data.created_by;
                    asset.description = data.description;
                    asset.email = data.email;
                    asset.file_name = data.file_name;
                }
            }

            _db.SaveChanges();
            return asset;
        }

        [System.Web.Http.HttpPut]
        public void UpdateAsset(Guid id, Assetdto assetdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            var assetdb = _db.assets.SingleOrDefault(a => a.asset_id == id);
            if (assetdb == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

            Mapper(assetdto, assetdb);
            _db.SaveChanges();
        }

        [System.Web.Http.HttpDelete]
        public void DeleteAsset(Guid id)
        {
            var assetdb = _db.assets.SingleOrDefault(a => a.asset_id == id);
            if (assetdb == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            _db.assets.Remove(assetdb);
            _db.SaveChanges();
        }

        //we can use automapper for this
        private void Mapper(Assetdto assetdto, Asset asset)
        {
            asset.asset_id = assetdto.asset_id;
            asset.country = assetdto.country;
            asset.created_by = assetdto.created_by;
            asset.description = assetdto.description;
            asset.email = assetdto.email;
            asset.file_name = assetdto.file_name;
            asset.mime_type = assetdto.mime_type;
        }
        private void MapperDto(Asset asset, Assetdto assetDto)
        {
            assetDto.asset_id = asset.asset_id;
            assetDto.country = asset.country;
            assetDto.created_by = asset.created_by;
            assetDto.description = asset.description;
            assetDto.email = asset.email;
            assetDto.file_name = asset.file_name;
            assetDto.mime_type = asset.mime_type;
        }
    }
}
