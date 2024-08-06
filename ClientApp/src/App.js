import React, { Component } from 'react';
import { BrowserRouter, Redirect, Route, Switch } from 'react-router-dom';
import { Layout } from './components/Layout';
import './custom.css'
import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer } from 'react-toastify';
import { Counter } from './components/Counter';
import { FetchData } from './components/FetchData';
import Logar from './Login/LoginPage';
import Logoff from './Login/Logoff';
import TokenProvider from './Login/Store';


export const App = () => {
    return (
        <>
            <BrowserRouter basename={window.ENV.aplicacao}>
                <ToastContainer />
                <Switch>
                    <Route exact path='/login' component={Logar} />
                    <TokenProvider>
                        <Route path='/sair' component={Logoff} />
                        <Layout>
                            <Route exact path='/' >
                                <Redirect to='/counter' component={Counter} />
                            </Route>
                            <Route exact path='/fetch-data' component={FetchData} />
                          
                        </Layout>
                    </TokenProvider>
                </Switch>
            </BrowserRouter>
        </>
    );
}
export default App;