import React, { Component, useEffect, useState } from 'react';


export default function CounterState() {
    const [counter, setCounter] = useState(0);


    //const aumentarCounter = () => {
    //    setCounter(counter + 1);
    //}

    useEffect(() => {
        window.alert();
    }, [counter])

    return (
        <div>
            <h1>Counter</h1>

            <p>This is a simple example of a React component.</p>

            <p aria-live="polite">Current count: <strong>{counter}</strong></p>

            <button className="btn btn-primary" onClick={() => setCounter(counter + 1)}>Increment</button>
        </div>
    );

}
