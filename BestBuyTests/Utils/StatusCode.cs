using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BestBuyTests.Utils
{
    public class StatusCode
    {

        public static void VerifySuccessStatusCode(IRestResponse restResponse) => Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

        public static void VerifyCreatesStatusCode(IRestResponse restResponse) => Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);

        public static void VerifyNotFoundStatusCode(IRestResponse restResponse) => Assert.AreEqual(HttpStatusCode.NotFound, restResponse.StatusCode);

    }
}
