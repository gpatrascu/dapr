import http from 'k6/http';
import {check} from 'k6';

export default function () {
    let shoppingCartId = CreateShoppingCart("aaa");
    AddArticle(shoppingCartId, "1", 1);
    AddArticle(shoppingCartId, "2", 2);
    AddArticle(shoppingCartId, "3", 1);
    
    GetShoppingCart(shoppingCartId);
}

function GetShoppingCart(shoppingCartId){
    const url = `https://localhost:8080/sc/shoppingCarts/${shoppingCartId}`;
    const res = http.get(url);
    
    console.log(res);

    check(res, {
        'response code was 200': (res) => res.status === 200,
    });
}

function CreateShoppingCart(userId) {
    const createShoppingCartUrl = 'https://localhost:8080/sc/shoppingCarts';
    const payload = JSON.stringify({
        userId: userId
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    const res = http.post(createShoppingCartUrl, payload, params);

    check(res, {
        'response code was 200': (res) => res.status === 200,
    });

    return res.json().id;
}

function AddArticle(shoppingCartId, articleId, quantity) {
    const url = `https://localhost:8080/sc/shoppingCarts/${shoppingCartId}/items`;
    const payload = JSON.stringify({
        articleId: articleId,
        quantity: quantity
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    const res = http.post(url, payload, params);

    //console.log(res);

    check(res, {
        'response code was 200': (res) => res.status === 200,
    });
}


