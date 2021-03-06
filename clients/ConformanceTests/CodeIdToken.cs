﻿using FluentAssertions;
using IdentityModel.OidcClient;
using System.Threading.Tasks;

namespace ConformanceTests
{
    // test descriptions can be found here: https://rp.certification.openid.net:8080/list?profile=CI
    public class CodeIdTokenTests
    {
        string _rpId = "identitymodel.oidcclient.code.id_token";
        
        public async Task Start()
        {
            //await rp_response_type_code_id_token();
            //await rp_scope_userinfo_claims();
            //await rp_nonce_unless_code_flow();
            //await rp_nonce_invalid();
            //await rp_token_endpoint_client_secret_basic();
            //await rp_id_token_aud();
            //await rp_id_token_kid_absent_single_jwks();
            //await rp_id_token_bad_c_hash();
            //await rp_id_token_issuer_mismatch();
            //await rp_id_token_kid_absent_multiple_jwks();
            //await rp_id_token_bad_sig_rs256();
            //await rp_id_token_iat();
            //await rp_id_token_sig_rs256();
            //await rp_id_token_sub();
            //await rp_userinfo_bad_sub_claim();
            //await rp_userinfo_bearer_header();
        }

        // Make an authentication request using the Hybrid Flow, specifying the response_type as 'code token'
        public async Task rp_response_type_code_id_token()
        {
            var helper = new Helper(_rpId, "rp-response_type-code+id_token");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;
            
            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeFalse();
            helper.ShowResult(result);
        }

        // 	Request claims using scope values.
        public async Task rp_scope_userinfo_claims()
        {
            var helper = new Helper(_rpId, "rp-scope-userinfo-claims");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid profile email address phone";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeFalse();
            helper.ShowResult(result);
        }

        // Always send a 'nonce' value as a request parameter while using implicit or hybrid flow. Verify the 'nonce' value returned in the ID Token.
        // An ID Token, either from the Authorization Endpoint or from the Token Endpoint, containing the same 'nonce' value as passed in the authentication request when using hybrid flow or implicit flow.
        public async Task rp_nonce_unless_code_flow()
        {
            var helper = new Helper(_rpId, "rp-nonce-unless-code-flow");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeFalse();
            helper.ShowResult(result);
        }

        // Pass a 'nonce' value in the Authentication Request. Verify the 'nonce' value returned in the ID Token.
        // Identify that the 'nonce' value in the ID Token is invalid and reject the ID Token.
        public async Task rp_nonce_invalid()
        {
            var helper = new Helper(_rpId, "rp-nonce-invalid");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeTrue();
            helper.ShowResult(result);
        }

        // Use the 'client_secret_basic' method to authenticate at the Authorization Server when using the token endpoint.
        public async Task rp_token_endpoint_client_secret_basic()
        {
            var helper = new Helper(_rpId, "rp-token_endpoint-client_secret_basic");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeFalse();
            helper.ShowResult(result);
        }

        // Request an ID token and compare its aud value to the Relying Party's 'client_id'.
        // Identify that the 'aud' value is missing or doesn't match the 'client_id' and reject the ID Token after doing ID Token validation.
        public async Task rp_id_token_aud()
        {
            var helper = new Helper(_rpId, "rp-id_token-aud");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeTrue();
            helper.ShowResult(result);
        }

        // Request an ID token and verify its signature using the keys provided by the Issuer.
        // Use the single key published by the Issuer to verify the ID Tokens signature and accept the ID Token after doing ID Token validation.
        public async Task rp_id_token_kid_absent_single_jwks()
        {
            var helper = new Helper(_rpId, "rp-id_token-kid-absent-single-jwks");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeFalse();
            helper.ShowResult(result);
        }

        // Retrieve Authorization Code and ID Token from the Authorization Endpoint, using Hybrid Flow. Verify the c_hash value in the returned ID token. 'id_token_signed_response_alg' must NOT be 'none'
        // Identify the incorrect 'c_hash' value and reject the ID Token after doing Authorization Code Validation.
        public async Task rp_id_token_bad_c_hash()
        {
            var helper = new Helper(_rpId, "rp-id_token-bad-c_hash");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeTrue();
            helper.ShowResult(result);
        }

        // Request an ID token and verify its 'iss' value.
        // Identify the incorrect 'iss' value and reject the ID Token after doing ID Token validation.
        public async Task rp_id_token_issuer_mismatch()
        {
            var helper = new Helper(_rpId, "rp-id_token-issuer-mismatch");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeTrue();
            helper.ShowResult(result);
        }

        // 	Request an ID token and verify its signature using the keys provided by the Issuer.
        // Identify that the 'kid' value is missing from the JOSE header and that the Issuer publishes multiple keys in its JWK Set document (referenced by 'jwks_uri'). 
        // The RP can do one of two things; reject the ID Token since it can not by using the kid determined which key to use to verify the signature. 
        // Or it can just test all possible keys and hit upon one that works, which it will in this case.
        public async Task rp_id_token_kid_absent_multiple_jwks()
        {
            var helper = new Helper(_rpId, "rp-id_token-kid-absent-multiple-jwks");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeFalse();
            helper.ShowResult(result);
        }

        // Request an ID token and verify its signature using the keys provided by the Issuer.
        // Identify the invalid signature and reject the ID Token after doing ID Token validation.
        public async Task rp_id_token_bad_sig_rs256()
        {
            var helper = new Helper(_rpId, "rp-id_token-bad-sig-rs256");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeTrue();
            helper.ShowResult(result);
        }

        // Request an ID token and verify its 'iat' value.
        // Identify the missing 'iat' value and reject the ID Token after doing ID Token validation.
        public async Task rp_id_token_iat()
        {
            var helper = new Helper(_rpId, "rp-id_token-iat");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeTrue();
            helper.ShowResult(result);
        }

        // Request an signed ID Token. Verify the signature on the ID Token using the keys published by the Issuer.
        // Accept the ID Token after doing ID Token validation.
        public async Task rp_id_token_sig_rs256()
        {
            var helper = new Helper(_rpId, "rp-id_token-sig-rs256");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeFalse();
            helper.ShowResult(result);
        }

        // Request an ID token and verify it contains a sub value.
        // Identify the missing 'sub' value and reject the ID Token.
        public async Task rp_id_token_sub()
        {
            var helper = new Helper(_rpId, "rp-id_token-sub");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeTrue();
            helper.ShowResult(result);
        }

        // Request an ID token and verify it contains a sub value.
        // Identify the missing 'sub' value and reject the ID Token.
        public async Task rp_userinfo_bad_sub_claim()
        {
            var helper = new Helper(_rpId, "rp-userinfo-bad-sub-claim");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeTrue();
            helper.ShowResult(result);
        }

        // Request an ID token and verify it contains a sub value.
        // Identify the missing 'sub' value and reject the ID Token.
        public async Task rp_userinfo_bearer_header()
        {
            var helper = new Helper(_rpId, "rp-userinfo-bearer-header");
            var options = await helper.RegisterForHybrid();

            options.Scope = "openid";
            options.Flow = OidcClientOptions.AuthenticationFlow.Hybrid;

            var client = new OidcClient(options);
            var result = await client.LoginAsync();

            result.IsError.Should().BeFalse();
            helper.ShowResult(result);
        }
    }
}