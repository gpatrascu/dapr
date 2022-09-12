#k6 run test.js --insecure-skip-tls-verify -e DaprUrl="https://20.101.212.6:8082/sc"
k6 run test.js --insecure-skip-tls-verify -e DaprUrl="https://20.101.212.6/sc" --vus 50 --duration 30s