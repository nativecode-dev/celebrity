namespace Celebrity.Core.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UriBuilderFluent
    {
        private readonly UriBuilder builder;

        private readonly IDictionary<string, string> parameters = new Dictionary<string, string>();

        public UriBuilderFluent()
        {
            this.builder = new UriBuilder();
        }

        public UriBuilderFluent(UriBuilder builder)
        {
            this.builder = builder;
            this.SetQuery(builder.Query);
        }

        public string AbsoluteUri => this.builder.Uri.AbsoluteUri;

        public Uri Uri => this.builder.Uri;

        public UriBuilderFluent SetHost(string host)
        {
            this.builder.Host = host;
            return this;
        }

        public UriBuilderFluent SetPath(string path)
        {
            this.builder.Path = path;
            return this;
        }

        public UriBuilderFluent SetPort(int port)
        {
            this.builder.Port = port;
            return this;
        }

        public UriBuilderFluent SetQuery(string query)
        {
            if (query.StartsWith("?"))
            {
                query = query.Substring(1);
            }

            var parts = query.Split('&');

            foreach (var part in parts)
            {
                var kvp = part.Split('=');
                var name = kvp[0].Trim();
                string value = null;

                if (kvp.Length > 1)
                {
                    value = kvp[1].Trim();
                }

                this.SetQuery(name, value);
            }

            return this;
        }

        public UriBuilderFluent SetQuery(string name, string value)
        {
            if (this.parameters.ContainsKey(name))
            {
                this.parameters[name] = value;
            }
            else
            {
                this.parameters.Add(name, value);
            }

            this.builder.Query = "?" + string.Join(string.Empty, this.parameters.Select(p => $"{p.Key}={p.Value}"));

            return this;
        }

        public UriBuilderFluent SetQueryClear()
        {
            this.parameters.Clear();
            this.builder.Query = null;
            return this;
        }

        public UriBuilderFluent SetScheme(string scheme)
        {
            this.builder.Scheme = scheme;
            return this;
        }
    }
}