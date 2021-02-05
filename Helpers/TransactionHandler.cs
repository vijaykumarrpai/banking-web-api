// using System;
// using System.Net.Http.Headers;
// using System.Security.Claims;
// using System.Text;
// using System.Text.Encodings.Web;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;
// using WebApi.Entities;
// using WebApi.Services;

// namespace WebApi.Helpers
// {
//     public class TransactionHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//     {
//         private readonly ITransactionService _transactionService;

//         public TransactionHandler(
//             IOptionsMonitor<AuthenticationSchemeOptions> options,
//             ILoggerFactory logger,
//             UrlEncoder encoder,
//             ISystemClock clock,
//             ITransactionService transactionService)
//             : base(options, logger, encoder, clock)
//         {
//             _transactionService = transactionService;
//         }

//         protected override async Task<AuthenticateResult> HandleTransactionAsync()
//         {
//             // skip authentication if endpoint has [AllowAnonymous] attribute
//             var endpoint = Context.GetEndpoint();
//             if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
//                 return AuthenticateResult.NoResult();

//             if (!Request.Headers.ContainsKey("Authorization"))
//                 return AuthenticateResult.Fail("Missing Transaction Header");

//             Transaction transaction = null;
//             try
//             {
//                 var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
//                 var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
//                 var entries = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
//                 var type = entries[0];
//                 var amount = entries[1];
//                 transaction = await _transactionService.Transaction(type, amount);
//             }
//             catch
//             {
//                 return AuthenticateResult.Fail("Invalid Transaction Entries");
//             }

//             if (transaction == null)
//                 return AuthenticateResult.Fail("Wrong type of transaction selected or domination amount");
//         }
//     }
// }