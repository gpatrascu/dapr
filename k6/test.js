import http from 'k6/http';

export default function () {
    const url = 'https://localhost:7000/shoppingCarts';
    const payload = JSON.stringify({
        userId: 'aaa'
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    http.post(url, payload, params);
}