import React, { Component } from 'react';

class SetButton extends Component {
    constructor(props) {
      super(props);
      this.seted = this.props.seted;
      this.handleClick = this.handleClick.bind(this);
    }
  
    handleClick() {
      this.setState(prevState => ({
        rent: !prevState.isToggleOn
      }));
    }
  
    render() {
      return (
        // <button onClick={this.handleClick}>
        //   {this.state.isToggleOn ? 'ON' : 'OFF'}
        // </button>
        <button
            type="button"
            className="btn btn-primary btn-sm"
            data-bs-toggle="modal"
            data-bs-target="#updateModal"
            onClick={this.seted}>Güncelle</button>
      );
    }
  }

  export default SetButton;