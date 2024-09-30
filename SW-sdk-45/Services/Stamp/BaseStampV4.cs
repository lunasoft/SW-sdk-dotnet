﻿using SW.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Stamp
{
    public abstract class BaseStampV4 : StampServiceV4
    {
        private string _operation;
        public BaseStampV4(string url, string user, string password, string operation, string proxy, int proxyPort) : base(url, user, password, proxy, proxyPort)
        {
            _operation = operation;
        }
        public BaseStampV4(string url, string token, string operation, string proxy, int proxyPort) : base(url, token, proxy, proxyPort)
        {
            _operation = operation;
        }
        public virtual StampResponseV1 TimbrarV1(string xml, string email = null, string customId = null, bool isb64 = false)
        {
            StampResponseHandlerV1 handler = new StampResponseHandlerV1();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = GetHeaders(email,customId);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return handler.GetPostResponse(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v1.ToString(),
                                format), headers, content, proxy);

            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual ConcurrentDictionary<string, StampResponseV1> TimbrarV1(string[] xmls, string email = null, bool isb64 = false)
        {
            StampResponseHandlerV1 handler = new StampResponseHandlerV1();
            ConcurrentBag<string> request = new ConcurrentBag<string>(xmls);
            ConcurrentDictionary<string, StampResponseV1> response = new ConcurrentDictionary<string, StampResponseV1>();

            string format = isb64 ? "b64" : "";
            Parallel.ForEach(request, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
            {
                try
                {
                    var xmlBytes = Encoding.UTF8.GetBytes(i);
                    var headers = GetHeaders(email);
                    var content = GetMultipartContent(xmlBytes);
                    var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                    response.TryAdd(i, handler.GetPostResponse(this.Url,
                                    string.Format("v4/cfdi33/{0}/{1}/{2}",
                                    _operation,
                                    StampTypes.v1.ToString(),
                                    format), headers, content, proxy));


                }
                catch (Exception ex)
                {
                    response.TryAdd(i, handler.HandleException(ex));
                }
            });
            return response;
        }
        public virtual StampResponseV2 TimbrarV2(string xml, string email = null, string customId = null, bool isb64 = false)
        {
            StampResponseHandlerV2 handler = new StampResponseHandlerV2();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = GetHeaders(email,customId);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return handler.GetPostResponse(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v2.ToString(),
                                format), headers, content, proxy);

            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual ConcurrentDictionary<string, StampResponseV2> TimbrarV2(string[] xmls, string email = null, bool isb64 = false)
        {
            StampResponseHandlerV2 handler = new StampResponseHandlerV2();
            ConcurrentBag<string> request = new ConcurrentBag<string>(xmls);
            ConcurrentDictionary<string, StampResponseV2> response = new ConcurrentDictionary<string, StampResponseV2>();

            string format = isb64 ? "b64" : "";
            Parallel.ForEach(request, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
            {
                try
                {
                    var xmlBytes = Encoding.UTF8.GetBytes(i);
                    var headers = GetHeaders(email);
                    var content = GetMultipartContent(xmlBytes);
                    var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                    response.TryAdd(i, handler.GetPostResponse(this.Url,
                                    string.Format("v4/cfdi33/{0}/{1}/{2}",
                                    _operation,
                                    StampTypes.v2.ToString(),
                                    format), headers, content, proxy));


                }
                catch (Exception ex)
                {
                    response.TryAdd(i, handler.HandleException(ex));
                }
            });
            return response;
        }
        public virtual StampResponseV3 TimbrarV3(string xml, string email = null, string customId = null, bool isb64 = false)
        {
            StampResponseHandlerV3 handler = new StampResponseHandlerV3();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = GetHeaders(email,customId);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return handler.GetPostResponse(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v3.ToString(),
                                format), headers, content, proxy);

            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        public virtual ConcurrentDictionary<string, StampResponseV3> TimbrarV3(string[] xmls, string email = null, bool isb64 = false)
        {
            StampResponseHandlerV3 handler = new StampResponseHandlerV3();
            ConcurrentBag<string> request = new ConcurrentBag<string>(xmls);
            ConcurrentDictionary<string, StampResponseV3> response = new ConcurrentDictionary<string, StampResponseV3>();

            string format = isb64 ? "b64" : "";
            Parallel.ForEach(request, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
            {
                try
                {
                    var xmlBytes = Encoding.UTF8.GetBytes(i);
                    var headers = GetHeaders(email);
                    var content = GetMultipartContent(xmlBytes);
                    var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                    response.TryAdd(i, handler.GetPostResponse(this.Url,
                                    string.Format("v4/cfdi33/{0}/{1}/{2}",
                                    _operation,
                                    StampTypes.v3.ToString(),
                                    format), headers, content, proxy));


                }
                catch (Exception ex)
                {
                    response.TryAdd(i, handler.HandleException(ex));
                }
            });
            return response;
        }
        public virtual StampResponseV4 TimbrarV4(string xml, string email = null, string customId = null, bool isb64 = false)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = GetHeaders(email,customId);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return handler.GetPostResponse(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}",
                                _operation,
                                StampTypes.v4.ToString(),
                                format), headers, content, proxy);

            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        //Método para reintento request
        public virtual StampResponseV4 TimbrarXmlV4(string xml, string email = null, string customId = null, bool isb64 = false)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4();
            try
            {
                return RetryHelper.Retry<StampResponseV4>(() =>
                {
                    string format = isb64 ? "b64" : "";
                    var xmlBytes = Encoding.UTF8.GetBytes(xml);
                    var headers = GetHeaders(email, customId);
                    var content = GetMultipartContent(xmlBytes);
                    var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                    var response = handler.GetPostResponse(this.Url,
                            string.Format("v4/cfdi33/{0}/{1}/{2}",
                            _operation,
                            StampTypes.v4.ToString(),
                            format), headers, content, proxy);
                    if(response.status.Equals("error"))
                        throw new Exception(response.message, new Exception(response.messageDetail));

                    return response;
                }, 3, 10);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }

        public virtual StampResponseV4 TimbrarV4Analytics(string xml, string email = null, string customId = null, bool isb64 = false)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4();
            try
            {
                string format = isb64 ? "b64" : "";
                var xmlBytes = Encoding.UTF8.GetBytes(xml);
                var headers = GetHeaders(email, customId);
                var content = GetMultipartContent(xmlBytes);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return handler.GetPostResponse(this.Url,
                                string.Format("v4/cfdi33/{0}/{1}/{2}/analytics",
                                _operation,
                                StampTypes.v4.ToString(),
                                format), headers, content, proxy);

            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }


        public virtual ConcurrentDictionary<string, StampResponseV4> TimbrarV4(string[] xmls, string email = null, bool isb64 = false)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4();
            ConcurrentBag<string> request = new ConcurrentBag<string>(xmls);
            ConcurrentDictionary<string, StampResponseV4> response = new ConcurrentDictionary<string, StampResponseV4>();

            string format = isb64 ? "b64" : "";
            Parallel.ForEach(request, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
            {
                try
                {
                    var xmlBytes = Encoding.UTF8.GetBytes(i);
                    var headers = GetHeaders(email);
                    var content = GetMultipartContent(xmlBytes);
                    var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                    response.TryAdd(i, handler.GetPostResponse(this.Url,
                                    string.Format("v4/cfdi33/{0}/{1}/{2}",
                                    _operation,
                                    StampTypes.v4.ToString(),
                                    format), headers, content, proxy));


                }
                catch (Exception ex)
                {
                    response.TryAdd(i, handler.HandleException(ex));
                }
            });
            return response;
        }
    }
}
