using RestSharp;
using RestSharp.Interceptors;
using RestSharp.Serializers.Json;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class ActiveCampaignServiceClient
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private readonly RestClient _restClient;
        private readonly string _apiKey;

        public ActiveCampaignServiceClient(string accountName, string apiKey)
        {
            RestClientOptions restClientOptions = new()
            {
                BaseUrl = new Uri($"https://{accountName}.api-us1.com/api/3/"),
            };
            _restClient = new(
                restClientOptions,
                configureSerialization: s => s.UseSystemTextJson(_jsonSerializerOptions));
            _apiKey = apiKey;
        }

        public async Task<ContactsCollectionResponse> ListContactsAsync(ListContactsOptions? options = null)
        {
            RestRequest request = new("contacts", Method.Get);
            if (options?.Email != null)
            {
                request.AddParameter("email", options.Email);
            }

            var response = await SendRequestAsync<ContactsCollectionResponse>(request);

            return response.Data!;
        }

        public async Task<ContactResponse> CreateContactAsync(CreateContactRequest createContactRequest)
        {
            RestRequest restRequest = new("contacts", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(new { contact = createContactRequest }, ContentType.Json);
            var response = await SendRequestAsync<ContactResponse>(restRequest);

            return response.Data!;
        }

        public async Task<ContactResponse> GetContactByIdAsync(int contactId)
        {
            RestRequest restRequest = new($"contacts/{contactId}", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            var response = await SendRequestAsync<ContactResponse>(restRequest);

            return response.Data!;
        }

        public async Task<ContactResponse> UpdateContactAsync(int contactId, UpdateContactRequest updateContactRequest)
        {
            RestRequest restRequest = new($"contacts/{contactId}", Method.Put);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            AddJsonBody(restRequest, new { contact = updateContactRequest });
            var response = await SendRequestAsync<ContactResponse>(restRequest);

            return response.Data!;
        }

        public async Task<ContactTagCollectionResponse> ListContactTagsAsync(string contactId)
        {
            RestRequest restRequest = new($"contacts/{contactId}/contactTags", Method.Get);
            var response = await SendRequestAsync<ContactTagCollectionResponse>(restRequest);

            return response.Data!;
        }

        public async Task<ContactTagResponse> AddContactTagAsync(int contactId, int tagId)
        {
            RestRequest restRequest = new($"contactTags", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            AddJsonBody(restRequest, new { contactTag = new { contact = contactId, tag = tagId } });
            var response = await SendRequestAsync<ContactTagResponse>(restRequest);

            return response.Data!;
        }

        public async Task DeleteContactTagAsync(string contactTagId)
        {
            RestRequest restRequest = new($"contactTags/{contactTagId}", Method.Delete);
            await SendRequestAsync<object>(restRequest);
        }

        public async Task<CustomerCollectionResponse> ListCustomersAsync(ListCustomersOptions? listCustomersOptions = null)
        {
            RestRequest request = new("ecomCustomers", Method.Get);
            if (listCustomersOptions?.ConnectionId.HasValue == true)
            {
                request.AddParameter("filters[connectionid]", listCustomersOptions.ConnectionId.Value);
            }

            if (listCustomersOptions?.Email is not null)
            {
                request.AddParameter("filters[email]", listCustomersOptions.Email);
            }

            if (listCustomersOptions?.ExternalId is not null)
            {
                request.AddParameter("filters[externalid]", listCustomersOptions.ExternalId);
            }

            var response = await SendRequestAsync<CustomerCollectionResponse>(request);
            return response.Data!;
        }

        public async Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest)
        {
            RestRequest restRequest = new("ecomCustomers", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(new { ecomCustomer = createCustomerRequest }, ContentType.Json);
            var response = await SendRequestAsync<CustomerResponse>(restRequest);

            return response.Data!;
        }

        public async Task<ECommerceOrdersCollectionResponse> ListEcommerceOrdersAsync(ListEcommerceOrdersOptions listOptions)
        {
            RestRequest request = new("ecomOrders", Method.Get);

            if (listOptions.Filters?.ConnectionId.HasValue == true)
            {
                request.AddParameter("filters[connectionid]", listOptions.Filters.ConnectionId.Value);
            }

            if (listOptions.Filters?.ExternalId is not null)
            {
                request.AddParameter("filters[externalid]", listOptions.Filters.ExternalId);
            }

            if (listOptions.Filters?.ExternalCheckoutId is not null)
            {
                request.AddParameter("filters[externalcheckoutid]", listOptions.Filters.ExternalCheckoutId);
            }

            if (listOptions.Filters?.Email is not null)
            {
                request.AddParameter("filters[email]", listOptions.Filters.Email);
            }

            if (listOptions.Filters?.State is not null)
            {
                request.AddParameter("filters[state]", (int)listOptions.Filters.State.Value);
            }

            if (listOptions.Filters?.CustomerId is not null)
            {
                request.AddParameter("filters[customerid]", listOptions.Filters.CustomerId);
            }

            if (listOptions.Filters?.ExternalCreatedDate is not null)
            {
                request.AddParameter("filters[external_created_date]", listOptions.Filters.ExternalCreatedDate.Value);
            }

            var response = await SendRequestAsync<ECommerceOrdersCollectionResponse>(request);
            return response.Data!;
        }

        public async Task<ECommerceOrderResponse> CreateECommerceOrder(CreateECommerceOrderRequest createOrderRequest)
        {
            RestRequest restRequest = new("ecomOrders", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(new { ecomOrder = createOrderRequest }, ContentType.Json);
            var response = await SendRequestAsync<ECommerceOrderResponse>(restRequest);

            return response.Data!;
        }

        public async Task<ECommerceOrderResponse> UpdateEcommerceOrderAsync(int ecomOrderId, UpdateEcommerceOrderRequest updateRequest)
        {
            RestRequest restRequest = new($"ecomOrders/{ecomOrderId}", Method.Put);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            AddJsonBody(restRequest, new { ecomOrder = updateRequest });
            var response = await SendRequestAsync<ECommerceOrderResponse>(restRequest);

            return response.Data!;
        }

        public async Task<ConnectionCollectionResponse> ListConnectionsAsync(ListConnectionsOptions? listConnectionsOptions = null)
        {
            RestRequest request = new("connections", Method.Get);
            if (listConnectionsOptions?.ExternalId is not null)
            {
                request.AddParameter("externalid", listConnectionsOptions.ExternalId);
            }

            if (listConnectionsOptions?.Service is not null)
            {
                request.AddParameter("service", listConnectionsOptions.Service);
            }

            var response = await SendRequestAsync<ConnectionCollectionResponse>(request);

            return response.Data!;
        }

        public async Task<ConnectionResponse> CreateConnectionAsync(CreateConnectionRequest createConnectionRequest)
        {
            RestRequest restRequest = new("connections", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(new { connection = createConnectionRequest }, ContentType.Json);
            var response = await SendRequestAsync<ConnectionResponse>(restRequest);

            return response.Data!;
        }

        public async Task<TagCollectionResponse> ListTagsAsync(ListTagsOptions? listOptions = null)
        {
            RestRequest restRequest = new($"tags", Method.Get);
            restRequest.AddHeader("Accept", "application/json");

            if (listOptions?.Search is not null)
            {
                restRequest.AddParameter("search", listOptions.Search);
            }

            if (listOptions?.Filters?.Tag is not null)
            {
                restRequest.AddParameter("filters[search][eq]", listOptions.Filters.Tag);
            }

            var response = await SendRequestAsync<TagCollectionResponse>(restRequest);

            return response.Data!;
        }

        public async Task<TagResponse> CreateTagAsync(CreateTagRequest createTagRequest)
        {
            RestRequest restRequest = new("tags", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(new { tag = createTagRequest }, ContentType.Json);
            var response = await SendRequestAsync<TagResponse>(restRequest);

            return response.Data!;
        }

        public async Task<TagResponse> GetTagAsync(string tagId)
        {
            RestRequest restRequest = new($"tags/{tagId}", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            var response = await SendRequestAsync<TagResponse>(restRequest);

            return response.Data!;
        }

        public async Task<CustomObjectSchemaCollectionResponse> ListCustomObjectSchemasAsync(ListCustomObjectSchemaOptions? listOptions = null)
        {
            RestRequest restRequest = new("customObjects/schemas", Method.Get);
            restRequest.AddHeader("Accept", "application/json");

            if (!string.IsNullOrWhiteSpace(listOptions?.Filters?.Slug))
            {
                restRequest.AddOrUpdateParameter("filters[slug]", listOptions.Filters.Slug);
            }

            var response = await SendRequestAsync<CustomObjectSchemaCollectionResponse>(restRequest);

            return response.Data!;
        }

        public async Task<CustomObjectSchemaResponse> GetCustomObjectSchemaAsync(string customObjectSchemaId)
        {
            RestRequest restRequest = new($"customObjects/schemas/{customObjectSchemaId}", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("showFields", "all");
            var response = await SendRequestAsync<CustomObjectSchemaResponse>(restRequest);

            return response.Data!;
        }

        public async Task<CustomObjectRecordCollectionResponse> ListCustomObjectRecordsAsync(string customObjectSchemaId, ListCustomObjectRecordsOptions listCustomObjectRecordsOptions)
        {
            RestRequest restRequest = new($"customObjects/records/{customObjectSchemaId}", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            if (listCustomObjectRecordsOptions?.Limit.HasValue == true)
            {
                restRequest.AddOrUpdateParameter("limit", listCustomObjectRecordsOptions.Limit.Value);
            }

            if (listCustomObjectRecordsOptions?.Offset.HasValue == true)
            {
                restRequest.AddOrUpdateParameter("offset", listCustomObjectRecordsOptions.Offset.Value);
            }

            if (listCustomObjectRecordsOptions?.Filters?.ContactId.HasValue == true)
            {
                restRequest.AddOrUpdateParameter("filters[relationships.primary-contact][eq]", listCustomObjectRecordsOptions.Filters.ContactId.Value);
            }

            var response = await SendRequestAsync<CustomObjectRecordCollectionResponse>(restRequest);
            return response.Data!;
        }

        public async Task<CustomObjectRecordResponse> CreateCustomObjectRecordAsync(string customObjectSchemaId, CreateCustomObjectRecordRequest createCustomObjectRecordRequest)
        {
            RestRequest restRequest = new($"customObjects/records/{customObjectSchemaId}", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(new { record = createCustomObjectRecordRequest }, ContentType.Json);
            var response = await SendRequestAsync<CustomObjectRecordResponse>(restRequest);

            return response.Data!;
        }

        public async Task<CustomObjectRecordResponse> GetCustomObjectRecordByExternalIdAsync(string customObjectSchemaId, string externalId)
        {
            RestRequest restRequest = new($"customObjects/records/{customObjectSchemaId}/external/{externalId}", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            var response = await SendRequestAsync<CustomObjectRecordResponse>(restRequest);
            return response.Data!;
        }

        public async Task<CustomObjectRecordResponse> UpdateCustomObjectRecordAsync(string customObjectSchemaId, string recordId, UpdateCustomObjectRecordRequest updateCustomObjectRecordRequest)
        {
            RestRequest restRequest = new($"customObjects/records/{customObjectSchemaId}", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            updateCustomObjectRecordRequest.Id = recordId;
            restRequest.AddJsonBody(new { record = updateCustomObjectRecordRequest }, ContentType.Json);
            var response = await SendRequestAsync<CustomObjectRecordResponse>(restRequest);

            return response.Data!;
        }

        public async Task<CustomObjectRecordResponse> UpdateCustomObjectRecordByExternalIdAsync(string customObjectSchemaId, string externalId, UpdateCustomObjectRecordRequest updateCustomObjectRecordRequest)
        {
            RestRequest restRequest = new($"customObjects/records/{customObjectSchemaId}", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");

            updateCustomObjectRecordRequest.Id = null;
            updateCustomObjectRecordRequest.ExternalId = externalId;
            restRequest.AddJsonBody(new { record = updateCustomObjectRecordRequest }, ContentType.Json);
            var response = await SendRequestAsync<CustomObjectRecordResponse>(restRequest);

            return response.Data!;
        }

        public async Task DeleteCustomObjectRecordAsync(string customObjectSchemaId, string recordId)
        {
            RestRequest restRequest = new($"customObjects/records/{customObjectSchemaId}/{recordId}", Method.Delete);
            await SendRequestAsync(restRequest);
        }

        public async Task DeleteCustomObjectRecordByExternalIdAsync(string customObjectSchemaId, string externalId)
        {
            RestRequest restRequest = new($"customObjects/records/{customObjectSchemaId}/external/{externalId}", Method.Delete);
            await SendRequestAsync(restRequest);
        }

        public async Task<CustomFieldCollectionResponse> ListCustomFields(ListCustomFieldsOptions listOptions)
        {
            RestRequest restRequest = new("fields", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            if (!string.IsNullOrWhiteSpace(listOptions?.Filters?.PersistentTag))
            {
                restRequest.AddOrUpdateParameter("filters[perstag]", listOptions.Filters.PersistentTag);
            }
            
            if (listOptions?.Limit.HasValue == true)
            {
                restRequest.AddOrUpdateParameter("limit", listOptions.Limit.Value);
            }

            var response = await SendRequestAsync<CustomFieldCollectionResponse>(restRequest);
            return response.Data!;
        }

        public async Task<CustomFieldResponse> CreateCustomFieldAsync(CreateCustomFieldRequest createRequest)
        {
            RestRequest restRequest = new("fields", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(new { field = createRequest }, ContentType.Json);

            var response = await SendRequestAsync<CustomFieldResponse>(restRequest);
            return response.Data!;
        }

        public async Task<FieldValueCollectionResponse> ListFieldValuesForContact(int contactId)
        {
            RestRequest restRequest = new($"contacts/{contactId}/fieldValues", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            var response = await SendRequestAsync<FieldValueCollectionResponse>(restRequest);

            return response.Data!;
        }

        public async Task CreateCustomFieldValueForContact(CreateOrUpdateCustomFieldValueRequest createOrUpdateRequest)
        {
            RestRequest restRequest = new("fieldValues", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(createOrUpdateRequest, ContentType.Json);

            await SendRequestAsync(restRequest);
        }

        public async Task UpdateCustomFieldValueForContactAsync(int fieldValueId, CreateOrUpdateCustomFieldValueRequest createOrUpdateRequest)
        {
            RestRequest restRequest = new($"fieldValues/{fieldValueId}", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(createOrUpdateRequest, ContentType.Json);

            await SendRequestAsync(restRequest);
        }

        private static void HandleResponse(RestResponse response)
        {
            try
            {
                response.ThrowIfError();
            }
            catch (JsonException ex)
            {
                ex.Data.Add("RawJson", response.Content);
                throw;
            }
            catch (Exception ex)
            {
                ActiveCampaignRequestException requestException;
                if (!string.IsNullOrWhiteSpace(response.Content)
                    && JsonSerializer.Deserialize<ErrorResponse>(response.Content, _jsonSerializerOptions) is ErrorResponse errorResponse)
                {
                    requestException = new(errorResponse, ex);
                }
                else
                {
                    requestException = new(ex.Message, ex);
                }

                string? requestContent = null;
                if (response.Request.Interceptors?.Find(i => i is FailedRequestInterceptor) is FailedRequestInterceptor failedRequestInterceptor)
                {
                    requestException.RequestMessage = failedRequestInterceptor.HttpRequestMessage;
                    if (!string.IsNullOrWhiteSpace(failedRequestInterceptor.RequestContent))
                    {
                        requestContent = failedRequestInterceptor.RequestContent;
                    }
                }

                Debug.WriteLine(requestException.Message + (requestContent is null ? string.Empty : Environment.NewLine + "Request body: " + requestContent));
                throw requestException;
            }
        }

        private void PrepareRequest(RestRequest request)
        {
            FailedRequestInterceptor failedRequestInterceptor = new();
            request.AddOrUpdateHeader("Api-Token", _apiKey);
            request.Interceptors ??= [];
            request.Interceptors.Add(failedRequestInterceptor);
        }

        private async Task<RestResponse> SendRequestAsync(RestRequest request)
        {
            PrepareRequest(request);
            RestResponse response = await _restClient.ExecuteAsync(request);

            HandleResponse(response);

            return response;
        }

        private async Task<RestResponse<T>> SendRequestAsync<T>(RestRequest request)
        {
            PrepareRequest(request);
            RestResponse<T> response = await _restClient.ExecuteAsync<T>(request);

            HandleResponse(response);

            return response;
        }

        private static void AddJsonBody<T>(RestRequest restRequest, T objectToSerialize)
        {
            string jsonSerializedObject = JsonSerializer.Serialize(objectToSerialize, _jsonSerializerOptions);
            restRequest.AddJsonBody(jsonSerializedObject, false, ContentType.Json);
        }

        private sealed class FailedRequestInterceptor : Interceptor
        {
            public HttpRequestMessage? HttpRequestMessage { get; private set; }

            public string? RequestContent { get; private set; }

            public override async ValueTask BeforeHttpRequest(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
            {
                HttpRequestMessage = requestMessage;

                if (requestMessage.Content is not null)
                {
                    using (MemoryStream ms = new())
                    {
                        await requestMessage.Content.CopyToAsync(ms, CancellationToken.None);
                        ms.Seek(0, SeekOrigin.Begin);
                        using (StreamReader sr = new(ms))
                        {
                            RequestContent = await sr.ReadToEndAsync(CancellationToken.None);
                        }
                    }
                }
            }
        }
    }
}
