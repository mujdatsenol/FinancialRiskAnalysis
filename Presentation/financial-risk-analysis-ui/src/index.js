import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import App from './App';
import PartnerList from './PartnerList';
import BusinessContractList from './BusinessContractList';
import BusinessTopicList from './BusinessTopicList';
import RiskAnalysisList from './RiskAnalysisList';
import reportWebVitals from './reportWebVitals';

// Bootstrap CSS
import "bootstrap/dist/css/bootstrap.min.css";
// Bootstrap Bundle JS
import "bootstrap/dist/js/bootstrap.bundle.min";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <nav className="navbar navbar-expand-lg bg-body-tertiary" style={{backgroundColor: '#afddfe'}}>
        <div className="container">
          <span className="navbar-brand mb-0 h1">Finansal Risk Analizi</span>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <div className="navbar-nav">
              <Link to="/" className="nav-link" aria-current="page" >İş Ortakları</Link>
              <Link to="/BusinessContract" className="nav-link" aria-current="page" >İş Anlaşmaları</Link>
              <Link to="/BusinessTopic" className="nav-link" aria-current="page" >İş Başlıkları</Link>
              <Link to="/RiskAnalysisList" className="nav-link" aria-current="page" >Risk Skorları</Link>
            </div>
          </div>
        </div>
      </nav>
      <Routes>
          <Route path='/' element={<PartnerList />} />
          <Route path='/BusinessContract' element={<BusinessContractList />} />
          <Route path='/BusinessTopic' element={<BusinessTopicList />} />
          <Route path='/RiskAnalysisList' element={<RiskAnalysisList />} />
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
