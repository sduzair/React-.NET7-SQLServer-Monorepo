export interface Product {
    productId: number;
    title: string;
    description: string;
    price: number;
    discountPercentage: number;
    rating: number;
    stock: number;
    brand: string;
    category: string;
    imageUrl: string;
    dateCreated: Date;
    dateUpdated: null;
    dateDeleted: null;
}


export interface ProductsURI {
    limit: number;
    sort: string;
    sortDirection: number;
    skip: number;
    category: string;
}

export enum ProductsUriReducerActions {
    ResetURI = "ResetURI",
    SortByPriceAscending = "SortByPriceAscending",
    SortByPriceDescending = "SortByPriceDescending",
    SortByRatingDescending = "SortByRatingDescending",
    ResetUriCategory = "ResetURICategory",
    SetUriCategory = "UpdateURICategory",
    SetUriLimit = "UpdateURILimit",
    SetUriSort = "UpdateURISort",
    UpdateURISkip = "UpdateURISkip",
    SetUriSortDirection = "UpdateURISortDirection",
    NextUriSkip = "NextURISkip",
    PreviousUriSkip = "PreviousURISkip",
    ResetUriSkip = "ResetURISkip",
}

export type ProductsUriReducerActionType =
    | { type: ProductsUriReducerActions.ResetURI }
    | { type: ProductsUriReducerActions.SortByPriceAscending }
    | { type: ProductsUriReducerActions.SortByPriceDescending }
    | { type: ProductsUriReducerActions.SortByRatingDescending }
    | { type: ProductsUriReducerActions.SetUriSort; payload: string }
    | { type: ProductsUriReducerActions.SetUriSortDirection; payload: number }
    | { type: ProductsUriReducerActions.ResetUriCategory }
    | { type: ProductsUriReducerActions.SetUriCategory; payload: string }
    | { type: ProductsUriReducerActions.SetUriLimit; payload: number }
    | { type: ProductsUriReducerActions.NextUriSkip }
    | { type: ProductsUriReducerActions.PreviousUriSkip }
    | { type: ProductsUriReducerActions.ResetUriSkip; }