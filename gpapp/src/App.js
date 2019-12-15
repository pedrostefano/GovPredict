import React, { Component } from "react";
import axios from "axios";

import Header from "./components/Header/Header";
import Filters from "./components/Filters/Filters";
import List from "./components/List/List";

import "./App.css";

class App extends Component {
  state = {
    postsData: {
      posts: [],
      summary: {}
    },
    filterOptions: {
      lists: ["Cool", "Bad"],
      socialNetworks: ["Facebook", "Twitter"]
    },
    filter: {
      content: "A",
      initialDate: new Date(new Date().getFullYear(),new Date().getMonth() , new Date().getDate()-1),
      finalDate: new Date(new Date().getFullYear(),new Date().getMonth() , new Date().getDate()),
      lists: [],
      socialNetworks: []
    }
  };

  componentDidMount() {
    axios.post(`https://localhost:5001/post/filter/1/10`, {}).then(res => {
      const postsData = res.data;
      this.setState({ postsData });
    });
  }

  getFilteredPosts = () => {
    axios
      .post(`https://localhost:5001/post/filter/1/10`, this.state.filter)
      .then(res => {
        const postsData = res.data;
        this.setState({ postsData });
      });
  };

  handleChangeContent = e => {
    const { filter } = this.state;
    filter.content = e.target.value;
    this.setState(filter);
  };

  handleInitialDateChange = value => {
    const { filter } = this.state;
    filter.initialDate = value;
    this.setState(filter);
  };

  handleFinalDateChange = value => {
    const { filter } = this.state;
    filter.finalDate = value;
    this.setState(filter);
  };

  handleChangeLists = event => {
    const { filter } = this.state;
    filter.lists = event.target.value;
    this.setState(filter);
  };

  handleChangeSocialNetworks = event => {
    const { filter } = this.state;
    filter.socialNetworks = event.target.value;
    this.setState(filter);
  };

  render() {
    return (
      <div className="App">
        <Header />
        <Filters
          options={this.state.filterOptions}
          filter={this.state.filter}
          click={this.getFilteredPosts}
          getFilteredPosts={this.getFilteredPosts}
          handleChangeContent={this.handleChangeContent}
          handleInitialDateChange={this.handleInitialDateChange}
          handleFinalDateChange={this.handleFinalDateChange}
          handleChangeLists={this.handleChangeLists}
          handleChangeSocialNetworks={this.handleChangeSocialNetworks}
        />
        <List posts={this.state.postsData.posts} />
      </div>
    );
  }
}

export default App;
