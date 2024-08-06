import React, { createContext, useState, useContext, useEffect } from "react";
import { useCookies } from 'react-cookie';
import Logar from "../Login/Logar";
import LoginPage from "../Login/LoginPage";


const TokenContext = createContext();

export default function TokenProvider({ children }) {
    const [token, setToken] = useState(null);

    const [cookies, setCookie] = useCookies(['access_token'])

    if (cookies.access_token) {
        return (
            <TokenContext.Provider value={{ token, setToken }}>
                {children}
            </TokenContext.Provider>
        )
    } else
        return (

            <TokenContext.Provider value={{ token, setToken }}>
                <LoginPage />
            </TokenContext.Provider>
        )

}



export function useDefault() {
    const context = useContext(TokenContext);
    const { token, setToken } = context;
    return { token, setToken };

}
