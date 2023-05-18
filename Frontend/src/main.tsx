import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import { BrowserRouter } from 'react-router-dom'
import App from './App.tsx'
import { ProSidebarProvider } from 'react-pro-sidebar'

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
    <BrowserRouter>
      <ProSidebarProvider>
        <App />
      </ProSidebarProvider>
    </BrowserRouter>
)
