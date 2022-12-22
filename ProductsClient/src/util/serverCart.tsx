
export async function addToRemoteCart(p) {
  const { stock, ...postProd } = p    // not storing "stock" of each product in cart
  const res = await fetch('api/carts/addoneproduct', {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'  //Content-Type: text/plain;charset=UTF-8
    },
    body: JSON.stringify(postProd)
  })
  // console.log(res);
  // console.log(postProd);
}

export async function removeOneFromRemoteCart(p) {
  const { stock, ...postProd } = p
  const res = await fetch("api/carts/removeoneproduct", {
    method: "PUT",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(postProd)
  })
  console.log(res)
}

// TODO: removeAllOfOneFromRemoteCart()
export async function removeAllOfOneFromRemoteCart(p) {
  const { stock, ...postProd } = p
  const res = await fetch("api/carts/removeallproductsofonetype", {
    method: "PUT",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(postProd)
  })
  console.log(res)
}