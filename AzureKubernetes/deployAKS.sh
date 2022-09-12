az group create --name kdapr --location westeurope

az aks create --resource-group kdapr --name kdaprcluster --node-count 2 --enable-addons http_application_routing --generate-ssh-keys

az aks get-credentials -n kdaprcluster -g kdapr

