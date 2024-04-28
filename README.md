# Aspire with Redis

A simple demo showing how to use .NET Aspire with Redis. The **AppHost** project is references [Aspire.Hosting.Redis](https://www.nuget.org/packages/Aspire.Hosting.Redis) and wires up the **redis resource**, and the **ApiApplication** references [Aspire.StackExchange.Redis](https://www.nuget.org/packages/Aspire.StackExchange.Redis) and wires up the **redis component**.

## Dashboard + OpenTelemetry

The aspire dashboard shows distributed traces that include the HTTP request to the API and the outgoing calls to redis. This works because **Aspire.StackExchange.Redis** enables OpenTelemetry for the redis client.

<img width="1200" alt="image" src="https://github.com/davidfowl/AspireWithRedis/assets/95136/d5824c06-413b-474f-9dcc-6908fc8622c1">
