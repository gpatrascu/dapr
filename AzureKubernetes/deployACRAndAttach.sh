MYACR=containerregistrygeorgepatrascudaprdemo

az acr create -n $MYACR -g kdapr --sku basic

az aks update -n kdaprcluster -g kdapr --attach-acr $MYACR