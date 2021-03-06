﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using System;
using AspNet.Security.OAuth.WordPress;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Builder {
    /// <summary>
    /// Extension methods to add WordPress authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class WordPressAuthenticationExtensions {
        /// <summary>
        /// Adds the <see cref="WordPressAuthenticationMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables WordPress authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="options">A <see cref="WordPressAuthenticationOptions"/> that specifies options for the middleware.</param>        
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseWordPressAuthentication(
            [NotNull] this IApplicationBuilder app,
            [NotNull] WordPressAuthenticationOptions options) {
            return app.UseMiddleware<WordPressAuthenticationMiddleware>(Options.Create(options));
        }

        /// <summary>
        /// Adds the <see cref="WordPressAuthenticationMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables WordPress authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="configuration">An action delegate to configure the provided <see cref="WordPressAuthenticationOptions"/>.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseWordPressAuthentication(
            [NotNull] this IApplicationBuilder app,
            [NotNull] Action<WordPressAuthenticationOptions> configuration) {
            var options = new WordPressAuthenticationOptions();
            configuration(options);

            return app.UseWordPressAuthentication(options);
        }
    }
}