import React from 'react'
import * as ReactDOM from "react-dom/client";
import App from './App.tsx'
import './index.css'
import {RouterProvider, createBrowserRouter } from 'react-router-dom';
import ErrorPage from './Components/ErrorPage.tsx';
import WorkZone from "./Components/WorkZone";

const router = createBrowserRouter([
  {
    path: "*",
    element: <App />,
    errorElement: <ErrorPage/>
  },
  {
    path: "/workzone",
    element: <WorkZone />,
    errorElement: <ErrorPage/>
  },
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <RouterProvider router={router} />
);
