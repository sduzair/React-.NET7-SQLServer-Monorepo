// import Col from 'node_modules/react-bootstrap/esm/Col'
import React, { useState } from 'react'
import { Col, Row, Pagination, Button } from 'react-bootstrap'
import ProductCard from '../components/ProductCard'
import { Product, ProductsURI, ProductsUriReducerActionType } from '../types';

type ProductsContainerProps = {
  products: Product[],
  dispatchCart: React.Dispatch<{
    type: any;
    payload: any;
  }>,
  cart: any[],
  dispatchProductsURI: React.Dispatch<ProductsUriReducerActionType>
}

const ProductsContainer = ({ products, dispatchCart, cart, dispatchProductsURI }: ProductsContainerProps) => {
  return (
    <>
      <Row className="row-cols-1 row-cols-lg-2 mb-5">
        {products.map((p, i) => (
          <ProductCard key={i} p={p} dispatchCart={dispatchCart} cart={cart} />
        ))}
      </Row>
      {/* <Row>
        <Pagination className="justify-content-center">
          <Pagination.First onClick={() => dispatchProductsURI({ type: 'ResetURISkip' })} />
          <Pagination.Prev onClick={() => dispatchProductsURI({ type: 'PrevURISkip' })} />
          <Pagination.Next onClick={() => dispatchProductsURI({ type: 'NextURISkip' })} />
          {/* <Pagination.Last /> *
        </Pagination>
      </Row> */}
    </>
  )
}

export default ProductsContainer
