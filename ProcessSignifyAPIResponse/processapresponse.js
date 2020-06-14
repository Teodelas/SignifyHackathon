var fs = require('fs');
var signifyjson = JSON.parse(fs.readFileSync('SignifyAssetDump.json','utf-8'));
var finaljson = JSON.parse('{"type": "FeatureCollection","features": []}');
var mapsjson = {};

for (i=0; i < signifyjson.Assets.length; i++) {
   var tmp = '{"type":"Feature","geometry":{"type":"Point","coordinates":[' + signifyjson.Assets[i].Longitude + ',' + signifyjson.Assets[i].Latitude + ']},"properties":{"Name":"' + signifyjson.Assets[i].Name + '", "Id":"", "ExternalAssetId":""}}';
   mapsjson = JSON.parse(tmp);
   mapsjson.properties.Id = signifyjson.Assets[i].Id;
   mapsjson.properties.ExternalAssetId = signifyjson.Assets[i].ExternalAssetId;
   finaljson.features.push(mapsjson);
}

console.log('starting')
fs.writeFile('SignifyPoiDataSet.json',JSON.stringify(finaljson));

