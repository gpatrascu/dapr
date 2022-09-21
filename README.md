`# dapr
dapr tests and demo


.Net services with Minimal API 
Service Discovery and Invocation, Pub/Sub, Distributed tracing

We will show how the same application can be moved fron one environment (local) to another (azure kubernetes) and how it can be configured to run with different components.


Run locally using Project Tye

Redis in a container for both state management and pub/sub messaging
Zipkin for tracing

The components for local execution are defined in components folder

```
.\components

pubsub.yaml
statestire.yaml
```


Run same application in AKS (Azure Kubernetes Service)
Azure Cache for redis - used for state management
Azure Service Bus used for pub/sub messaging
Application Insights for trace

The components for running in Azure Kubernetes Service are in folder 

```
.\kubernetscomponents

azure-service-bus-pubsub.yaml
collector-config.yaml
open-telemetry-collector-appinsights.yaml
redis-statestore.yaml
redis-pubsub.yaml -- this is a possibility. In azure we used the azure service bus during the demo

```

In order to execute some tests we used k6 to run tests on both local and AKS

you can see the test files in the k6 folder

```
.\k6
```


The demo and the code was written on a ubuntu virtual machine without a desktop. 
For development I used Rider Jetbrains with remote development feature.




