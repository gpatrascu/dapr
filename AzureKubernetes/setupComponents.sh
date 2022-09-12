#kubectl create secret generic redis --from-literal=redis-password=4DOzsSf8tDWnjCKc3F37UN2oBXBapME53AzCaFYSOwY=

kubectl apply -f ~/work/dapr/kubernetscomponents/redis-statestore.yaml
kubectl apply -f ~/work/dapr/kubernetscomponents/redis-pubsub.yaml

