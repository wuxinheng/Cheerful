using Newtonsoft.Json.Bson;
using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;

namespace Happy.Test
{
    [TestClass]
    public class RequstApiTest
    {
        [TestMethod("Post 请求")]
        public async Task TestMethod1()
        {
            var webClient = new WebClient();
            byte[] Bytes = webClient.DownloadData("http://47.100.94.46:2023/api/file/preview?fileName=09f387ad-26fa-45ee-8860-11866f664e1f.jpg&applictionName=Property");
            var stream = new MemoryStream(Bytes);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://39.101.161.175:8088/fastgate/person"),
                Headers =
                {
                    { "Cookie", "JSESSIONID=A0B5A9070F5A1FDC7E2C563AF433E9E9; COMMONID=A0B5A9070F5A1FDC7E2C563AF433E9E9" },
                },
                Content = new MultipartFormDataContent
                {
                    new StringContent("2wer11")
                    {
                        Headers =
                        {
                            ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "Name",
                            }
                        }
                    },
                    new StringContent("2wer11")
                    {
                        Headers =
                        {
                            ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "Code",
                            }
                        }
                    },
                    new StringContent("TEST")
                    {
                        Headers =
                        {
                            ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "Depart",
                            }
                        }
                    },
                    new StreamContent(stream)
                    {
                        Headers =
                        {
                            ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "file",
                                FileName = "屏幕截图 2022-10-29 145554.png",
                            },
                            ContentType=new MediaTypeHeaderValue("image/png")
                        }
                    },
                    new StringContent("1")
                    {
                        Headers =
                        {
                            ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "Sex",
                            }
                        }
                    },

                },
            };
             await RequstApi.PostAsync(request);
        }

        [TestMethod("网络资源转Byte[]")]
        public void TestMethod2()
        {

            var result = RequstApi.DownloadToByte("http://47.100.94.46:2023/api/file/preview?fileName=09f387ad-26fa-45ee-8860-11866f664e1f.jpg&applictionName=Property");
        }

        [TestMethod("网络资源转Stream")]
        public void TestMethod3()
        {
            RequstApi.DownloadToStream("http://47.100.94.46:2023/api/file/preview?fileName=09f387ad-26fa-45ee-8860-11866f664e1f.jpg&applictionName=Property");
        }
    }
}