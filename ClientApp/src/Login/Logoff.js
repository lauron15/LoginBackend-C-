import React, { useState, useCallback } from 'react';
import { Redirect } from 'react-router';
import { Link } from 'react-router-dom';
import { useCookies } from 'react-cookie'
import cookie from 'react-cookies';
import { ToastContainer, toast } from 'react-toastify';


export default function Logoff() {


    if (cookie.load('old_access_token')) {

        cookie.save('access_token', cookie.load('old_access_token'), { path: '/' });
        cookie.save('cpfCns', cookie.load('old_cpfCns'), { path: '/' });



        cookie.remove('old_access_token', { path: '/' });
        return <Redirect push to="/meuperfil" />;
    } else {
        cookie.remove('access_token', { path: '/' });
        cookie.remove('estabelecimentoPadrao', { path: '/' });
        cookie.remove('funcionarioPadrao', { path: '/' });
        cookie.remove('cboPadrao', { path: '/' });


        return <Redirect push to="/login" />;
    }
}

