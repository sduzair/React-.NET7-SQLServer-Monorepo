import { Container, Row, Col } from 'react-bootstrap';
import React, { useEffect, useReducer, useState } from 'react'
import ProductsContainer from './pages/ProductsPage'
import NewProductPage from './pages/NewProductPage'
import Header from './Header'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import CartOffCanvas from './components/CartOffCanvas'
import FilterPanel from './components/FilterPanel'
import SortPanel from './components/SortPanel'
import { ProductsUriReducerActions, ProductsURI, Product, ProductsUriReducerActionType } from './types';

const hardcodedData = [
  {
    "id": "62fbdfffb7bb58ebda36b371",
    "secondID": 1,
    "title": "iPhone 9",
    "description": "An apple mobile which is nothing like apple",
    "price": 549,
    "discountPercentage": 12.96,
    "rating": 4.69,
    "stock": 94,
    "brand": "Apple",
    "category": "smartphones",
    "thumbnail": "https://dummyjson.com/image/i/products/1/thumbnail.jpg",
    "images": [
      "https://dummyjson.com/image/i/products/1/1.jpg",
      "https://dummyjson.com/image/i/products/1/2.jpg",
      "https://dummyjson.com/image/i/products/1/3.jpg",
      "https://dummyjson.com/image/i/products/1/4.jpg",
      "https://dummyjson.com/image/i/products/1/thumbnail.jpg"
    ]
  },
  {
    "id": "62fbdfffb7bb58ebda36b372",
    "secondID": 2,
    "title": "iPhone X",
    "description": "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...",
    "price": 899,
    "discountPercentage": 17.94,
    "rating": 4.44,
    "stock": 34,
    "brand": "Apple",
    "category": "smartphones",
    "thumbnail": "https://dummyjson.com/image/i/products/2/thumbnail.jpg",
    "images": [
      "https://dummyjson.com/image/i/products/2/1.jpg",
      "https://dummyjson.com/image/i/products/2/2.jpg",
      "https://dummyjson.com/image/i/products/2/3.jpg",
      "https://dummyjson.com/image/i/products/2/thumbnail.jpg"
    ]
  },
  {
    "id": "62fbdfffb7bb58ebda36b373",
    "secondID": 3,
    "title": "Samsung Universe 9",
    "description": "Samsung's new variant which goes beyond Galaxy to the Universe",
    "price": 1249,
    "discountPercentage": 15.46,
    "rating": 4.09,
    "stock": 36,
    "brand": "Samsung",
    "category": "smartphones",
    "thumbnail": "https://dummyjson.com/image/i/products/3/thumbnail.jpg",
    "images": [
      "https://dummyjson.com/image/i/products/3/1.jpg"
    ]
  },
  {
    "id": "62fbdfffb7bb58ebda36b374",
    "secondID": 4,
    "title": "OPPOF19",
    "description": "OPPO F19 is officially announced on April 2021.",
    "price": 280,
    "discountPercentage": 17.91,
    "rating": 4.3,
    "stock": 123,
    "brand": "OPPO",
    "category": "smartphones",
    "thumbnail": "https://dummyjson.com/image/i/products/4/thumbnail.jpg",
    "images": [
      "https://dummyjson.com/image/i/products/4/1.jpg",
      "https://dummyjson.com/image/i/products/4/2.jpg",
      "https://dummyjson.com/image/i/products/4/3.jpg",
      "https://dummyjson.com/image/i/products/4/4.jpg",
      "https://dummyjson.com/image/i/products/4/thumbnail.jpg"
    ]
  },
  {
    "id": "62fbdfffb7bb58ebda36b375",
    "secondID": 5,
    "title": "Huawei P30",
    "description": "Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK.",
    "price": 499,
    "discountPercentage": 10.58,
    "rating": 4.09,
    "stock": 32,
    "brand": "Huawei",
    "category": "smartphones",
    "thumbnail": "https://dummyjson.com/image/i/products/5/thumbnail.jpg",
    "images": [
      "https://dummyjson.com/image/i/products/5/1.jpg",
      "https://dummyjson.com/image/i/products/5/2.jpg",
      "https://dummyjson.com/image/i/products/5/3.jpg"
    ]
  },
  {
    "id": "62fbdfffb7bb58ebda36b376",
    "secondID": 6,
    "title": "MacBook Pro",
    "description": "MacBook Pro 2021 with mini-LED display may launch between September, November",
    "price": 1749,
    "discountPercentage": 11.02,
    "rating": 4.57,
    "stock": 83,
    "brand": "APPle",
    "category": "laptops",
    "thumbnail": "https://dummyjson.com/image/i/products/6/thumbnail.png",
    "images": [
      "https://dummyjson.com/image/i/products/6/1.png",
      "https://dummyjson.com/image/i/products/6/2.jpg",
      "https://dummyjson.com/image/i/products/6/3.png",
      "https://dummyjson.com/image/i/products/6/4.jpg"
    ]
  },
  {
    "id": "62fbdfffb7bb58ebda36b377",
    "secondID": 7,
    "title": "Samsung Galaxy Book",
    "description": "Samsung Galaxy Book S (2020) Laptop With Intel Lakefield Chip, 8GB of RAM Launched",
    "price": 1499,
    "discountPercentage": 4.15,
    "rating": 4.25,
    "stock": 50,
    "brand": "Samsung",
    "category": "laptops",
    "thumbnail": "https://dummyjson.com/image/i/products/7/thumbnail.jpg",
    "images": [
      "https://dummyjson.com/image/i/products/7/1.jpg",
      "https://dummyjson.com/image/i/products/7/2.jpg",
      "https://dummyjson.com/image/i/products/7/3.jpg",
      "https://dummyjson.com/image/i/products/7/thumbnail.jpg"
    ]
  },
  {
    "id": "62fbdfffb7bb58ebda36b378",
    "secondID": 8,
    "title": "Microsoft Surface Laptop 4",
    "description": "Style and speed. Stand out on HD video calls backed by Studio Mics. Capture ideas on the vibrant touchscreen.",
    "price": 1499,
    "discountPercentage": 10.23,
    "rating": 4.43,
    "stock": 68,
    "brand": "Microsoft Surface",
    "category": "laptops",
    "thumbnail": "https://dummyjson.com/image/i/products/8/thumbnail.jpg",
    "images": [
      "https://dummyjson.com/image/i/products/8/1.jpg",
      "https://dummyjson.com/image/i/products/8/2.jpg",
      "https://dummyjson.com/image/i/products/8/3.jpg",
      "https://dummyjson.com/image/i/products/8/4.jpg",
      "https://dummyjson.com/image/i/products/8/thumbnail.jpg"
    ]
  },
  {
    "id": "62fbdfffb7bb58ebda36b379",
    "secondID": 9,
    "title": "Infinix INBOOK",
    "description": "Infinix Inbook X1 Ci3 10th 8GB 256GB 14 Win10 Grey – 1 Year Warranty",
    "price": 1099,
    "discountPercentage": 11.83,
    "rating": 4.54,
    "stock": 96,
    "brand": "Infinix",
    "category": "laptops",
    "thumbnail": "https://dummyjson.com/image/i/products/9/thumbnail.jpg",
    "images": [
      "https://dummyjson.com/image/i/products/9/1.jpg",
      "https://dummyjson.com/image/i/products/9/2.png",
      "https://dummyjson.com/image/i/products/9/3.png",
      "https://dummyjson.com/image/i/products/9/4.jpg",
      "https://dummyjson.com/image/i/products/9/thumbnail.jpg"
    ]
  },
  {
    "id": "62fbdfffb7bb58ebda36b37a",
    "secondID": 10,
    "title": "HP Pavilion 15-DK1056WM",
    "description": "HP Pavilion 15-DK1056WM Gaming Laptop 10th Gen Core i5, 8GB, 256GB SSD, GTX 1650 4GB, Windows 10",
    "price": 1099,
    "discountPercentage": 6.18,
    "rating": 4.43,
    "stock": 89,
    "brand": "HP Pavilion",
    "category": "laptops",
    "thumbnail": "https://dummyjson.com/image/i/products/10/thumbnail.jpeg",
    "images": [
      "https://dummyjson.com/image/i/products/10/1.jpg",
      "https://dummyjson.com/image/i/products/10/2.jpg",
      "https://dummyjson.com/image/i/products/10/3.jpg",
      "https://dummyjson.com/image/i/products/10/thumbnail.jpeg"
    ]
  }
]

const initialProductsState = {
  loading: true,
  error: '',
  products: [
    { id: "<id>", brand: "<brand>", title: "<title>", stock: 0, quantityInCart: 0 }
  ],
  totalCartQuantity: 0
}
// 'api/Products/GetAll?limit=10&sort=id&sortDirection=1&skip=0'
const initialProductsURI: ProductsURI = {
  limit: 10,
  sort: "id",
  sortDirection: 1,
  skip: 0,
  category: "all",
}

const App = () => {
  const [stateCart, dispatchCart] = useReducer(reducerCart, [])
  const [stateProducts, dispatchProducts] = useReducer(reducerProducts, initialProductsState);
  const [stateProductsURI, dispatchProductsURI] = useReducer(reducerProductsURI, initialProductsURI);



  useEffect(() => {
    // fetching products
    // console.log("Running use effect");
    // const fetchURI = `api/Products/GetAll?${new URLSearchParams(stateProductsURI).toString()}`
    // convert the stateProductsURI to a string and then to a URLSearchParams object
    const fetchURI = `api/products?${new URLSearchParams(stateProductsURI as unknown as Record<string, string>).toString()}`
    // const fetchURI = "api/products"


    console.log(fetchURI);
    const getProducts = async () => {
      try {
        const res = await fetch(fetchURI)
        const data = await res.json();
        dispatchProducts({ type: "FetchSuccess", payload: data })
        console.log(data);
      } catch (error) {
        dispatchProducts({ type: "FetchFailure", payload: "Error retreiving products data" })
        console.log(error)
      }
    }
    getProducts();
    dispatchProducts({ type: "FetchSuccess", payload: hardcodedData })
  }, [stateProductsURI])
  useEffect(() => {
    // fetching cart 
    const getCart = async () => {
      try {
        const res = await fetch('api/carts/get', {
          method: "GET"
        })
        const data = await res.json()
        // console.log(data);
        // run dispatch to add the products to cart
        data.cartItems.forEach((prod: Product) => dispatchCart({ type: "AddToCart", payload: prod }))

      } catch (error) {
        console.log(error);
      }
    }
    // getCart();
  }, [])

  return (
    <Router>
      <Header cart={stateCart} dispatch={dispatchCart} />
      <Routes>
        <Route path="/" element={
          <Container fluid className="mx-auto">
            <Row>
              <Col xs={12} md={2} className='card shadow-0 border rounded-3'>
                <FilterPanel dispatchProductsURI={dispatchProductsURI} />
              </Col>
              <Col xs={12} md={10}>
                <SortPanel dispatchProductsURI={dispatchProductsURI} />
                {!stateProducts.loading ? stateProducts.error ? stateProducts.error : <ProductsContainer products={stateProducts.products} dispatchCart={dispatchCart} cart={stateCart} dispatchProductsURI={dispatchProductsURI} /> : "..loading"}
              </Col>
            </Row>
          </Container>
        } />
        {/* <Route path="/new" element={<NewProductPage />} /> */}
        {/* <Route path="/about" component={About} /> */}
      </Routes>
    </Router>
  )
}

export default App;




function reducerProductsURI(state: ProductsURI, action: ProductsUriReducerActionType): ProductsURI {
  switch (action.type) {
    case ProductsUriReducerActions.ResetURI:
      const initialProductsURI = {
        limit: 10,
        sort: "id",
        sortDirection: 1,
        skip: 0,
        category: "all",
      }
      return { ...state, ...initialProductsURI }
    case ProductsUriReducerActions.SortByPriceAscending:
      return { ...state, sort: "price", sortDirection: 1 }
    case ProductsUriReducerActions.SortByPriceDescending:
      return { ...state, sort: "price", sortDirection: -1 }
    case ProductsUriReducerActions.SortByRatingDescending:
      return { ...state, sort: "rating", sortDirection: -1 }
    case ProductsUriReducerActions.ResetUriCategory:
      return { ...state, category: "all" }
    case ProductsUriReducerActions.SetUriCategory:
      return {
        ...state,
        category: action.payload
      }
    case ProductsUriReducerActions.SetUriLimit:
      return {
        ...state,
        limit: action.payload
      }
    case ProductsUriReducerActions.SetUriSort:
      return {
        ...state,
        sort: action.payload
      }
    case ProductsUriReducerActions.SetUriSortDirection:
      return {
        ...state,
        sortDirection: action.payload
      }
    case ProductsUriReducerActions.NextUriSkip:
      return {
        ...state,
        skip: state.skip + 10
      }
    case ProductsUriReducerActions.PreviousUriSkip:
      if (state.skip === 0) {
        return state
      }
      return {
        ...state,
        skip: state.skip - 10
      }
    case ProductsUriReducerActions.ResetUriSkip:
      return {
        ...state,
        skip: 0
      }
    // default:
    //   throw new Error();
  }
}

function reducerCart(state: any[], action: { type: any; payload: any; }) {
  // store cart in server session
  switch (action.type) {
    case "AddToCart":
      return ([
        ...state,
        action.payload
      ])
    case "RemoveAllFromCart":
      return state.filter((p: { id: any; }) => { return p.id !== action.payload })
    case "RemoveOneFromCart":
      let first = 1
      return state.filter((p: { id: any; }) => {
        if (p.id === action.payload && first === 1) {
          first = 0
          return false
        }
        else return true
      })
    default:
      throw new Error();
  }
}

function reducerProducts(state: any, action: { type: any; payload: any; }) {
  switch (action.type) {
    case "FetchSuccess":
      return {
        loading: false,
        error: '',
        products: action.payload.map((p: any) => ({ ...p, quantityInCart: 0 })),
        totalCartQuantity: 0
      }
    case "FetchFailure":
      return {
        ...state,
        loading: false,
        error: action.payload,
      }
    default:
      throw new Error();
  }
};